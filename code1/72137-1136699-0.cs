    using System;
    using System.Diagnostics;
    using System.Linq.Expressions;
    class Program
    {
        DateTime MethodOfDoom(string s, int i)
        {
            return DateTime.Today;
        }
        public void RunTest()
        {
            int i =123;
            Log.Capture(() => this.MethodOfDoom("abc", i));
        }
        static void Main()
        {
            new Program().RunTest();
        }
    }
    static class Log
    {
        public static T Capture<T>(Expression<Func<T>> method)
        {   
            MethodCallExpression mce = method.Body as MethodCallExpression;
            if (mce == null) throw new InvalidOperationException(
                 "Method-call expected");
            string name = mce.Method.Name;
            try
            {
                int i = 0;
                foreach(var param in mce.Method.GetParameters())
                {
                    object argValue = Expression.Lambda(mce.Arguments[i++])
                            .Compile().DynamicInvoke();
                    Trace.WriteLine(param.Name + "=" + argValue, name);
                }
                Trace.WriteLine("ENTERING", name);
                T result = method.Compile().Invoke();
                Trace.WriteLine("EXITING: " + result, name);
                return result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("EXCEPTION: " + ex, name);
                throw;
            }
        }
    }
