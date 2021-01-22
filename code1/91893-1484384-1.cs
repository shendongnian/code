    using System;
    using System.Runtime.Remoting.Messaging;
    public class Calculator
    {
        private delegate Int32 AddDelegate(Int32 a, Int32 b);
        public Int32 Add(Int32 a, Int32 b)
        {
            return a + b;
        }
    
        public IAsyncResult BeginAdd(Int32 a, Int32 b,
            AsyncCallback callback, Object obj)
        {
            return new AddDelegate(Add).BeginInvoke(a, b, callback, obj);
        }
    
        public Int32 EndAdd(IAsyncResult ar)
        {
            var d = (AddDelegate)((AsyncResult)ar).AsyncDelegate;
            return d.EndInvoke(ar);
        }
    }
    static class Program
    {
        static void Main()
        {
            Calculator calc = new Calculator();
            int x = 1, y = 2;
            Async.Run<int>(
                (ac,o)=>calc.BeginAdd(x,y,ac,o),
                calc.EndAdd, result =>
                {
                    Console.WriteLine(result());
                });
            Console.ReadLine();
        }
    }
    static class Async
    {
        public static void Run<T>(
        Func<AsyncCallback, object, IAsyncResult> begin,
        Func<IAsyncResult, T> end,
        Action<Func<T>> callback)
        {
            begin(ar =>
            {
                T result;
                try
                {
                    result = end(ar); // ensure end called
                    callback(() => result);
                }
                catch (Exception ex)
                {
                    callback(() => { throw ex; });
                }
            }, null);
        }
    }
