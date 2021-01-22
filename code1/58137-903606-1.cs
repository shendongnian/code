    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    class Foo {
        public string Bar {get;set;}
        public int someMethod() { return 4; }
        public int OtherProperty { get { return 3; } }
    }
    static class Program
    {
        static int someMethod() { return 3; }
        static void Main()
        {
            Foo foo = new Foo();
            Test<Foo>(x => x.Bar.ExtMethod(5), foo);
            Test<Foo>(x => x.Bar.ExtMethod(new object()), foo);
            Test<Foo>(x => x.Bar.ExtMethod(someMethod()), foo);
            Test<Foo>(x => x.Bar.ExtMethod(x.someMethod()), foo);
            Test<Foo>(x => x.Bar.ExtMethod(x.OtherProperty), foo);
        }
        static void Test<T>(Expression<Func<T, string>> expr, T instance)
        {
            if (expr.Body.NodeType != ExpressionType.Call)
            {
                throw new InvalidOperationException("Call expected");
            }
            var call = ((MethodCallExpression)expr.Body);
            if (call.Method != typeof(Program).GetMethod(
                "ExtMethod", BindingFlags.Static | BindingFlags.NonPublic))
            {
                throw new InvalidOperationException("ExtMethod expected");
            }
            // we know that ExtMethod has 2 args; pick myParameter (the 2nd);
            // then build an expression over arg, re-using our outer param
            var newLambda = Expression.Lambda<Func<T, object>>(
                call.Arguments[1], expr.Parameters[0]);
    
            // evaluate it and show the argument value
            object value = newLambda.Compile()(instance);
            Console.WriteLine(value);
        }
        static string ExtMethod(this object self, object myParameter) {
            return self.ToString();
        }
    }
