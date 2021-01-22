C# 4.0 has dynamic language runtime feature, so how about using the dynamic type?
    using Microsoft.CSharp.RuntimeBinder;
    namespace ListOperatorsTest
    {
    class Program
    {
        public static void ListOperators(object inst)
        {
            dynamic d = inst;
            try
            {
                var eq = d == d; // Yes, IntelliSense gives a warning here.
                // Despite this code looks weird, it will do
                // what it's supposed to do :-)
                Console.WriteLine("Type {0} supports ==", inst.GetType().Name);
            }
            catch (RuntimeBinderException)
            {
            }
            try
            {
                var eq = d <= d;
                Console.WriteLine("Type {0} supports <=", inst.GetType().Name);
            }
            catch (RuntimeBinderException)
            {
            }
            try
            {
                var eq = d < d;
                Console.WriteLine("Type {0} supports <", inst.GetType().Name);
            }
            catch (RuntimeBinderException)
            {
            }
            try
            {
                var add = d + d;
                Console.WriteLine("Type {0} supports +", inst.GetType().Name);
            }
            catch (RuntimeBinderException)
            {
            }
            try
            {
                var sub = d - d;
                Console.WriteLine("Type {0} supports -", inst.GetType().Name);
            }
            catch (RuntimeBinderException)
            {
            }
            try
            {
                var mul = d * d;
                Console.WriteLine("Type {0} supports *", inst.GetType().Name);
            }
            catch (RuntimeBinderException)
            {
            }
            try
            {
                try
                {
                    var div = d / d;
                }
                catch (DivideByZeroException)
                {
                }
                Console.WriteLine("Type {0} supports /", inst.GetType().Name);
            }
            catch (RuntimeBinderException)
            {
            }
        }
        private struct DummyStruct
        {
        }
        static void Main(string[] args)
        {
            ListOperators(0);
            ListOperators(0.0);
            DummyStruct ds;
            ListOperators(ds);
            ListOperators(new Guid());
        }
    }
    }
