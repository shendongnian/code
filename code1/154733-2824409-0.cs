    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    class Foo {
        public string Bar { get; set; }
        static void Main() {
            // take a "get" from C#
            Expression<Func<Foo, string>> get = foo => foo.Bar;
            // re-write in .NET 4.0 as a "set"
            var member = (MemberExpression)get.Body;
            var param = Expression.Parameter(typeof(string), "value");
            var set = Expression.Lambda<Action<Foo, string>>(
                Expression.Assign(member, param), get.Parameters[0], param);
            // comile it
            var action = set.Compile();
            var inst = new Foo();
            action(inst, "abc");
            Console.WriteLine(inst.Bar); // show it working
            //==== reflection
            MethodInfo setMethod = ((PropertyInfo)member.Member).GetSetMethod();
            setMethod.Invoke(inst, new object[] { "def" });
            Console.WriteLine(inst.Bar); // show it working
            //==== Delegate.CreateDelegate
            action = (Action<Foo, string>)
                Delegate.CreateDelegate(typeof(Action<Foo, string>), setMethod);
            action(inst, "ghi");
            Console.WriteLine(inst.Bar); // show it working
        }
    }
