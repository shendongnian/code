    using System;
    using System.Threading;
    
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Call(i);
            }
    
            Thread.Sleep(999);
        }
    
        static unsafe void Call(int number)
        {
            Helper helper = new Helper();
            int* tmp = stackalloc int[64];
            helper.ints = tmp;
            helper.ints[32] = number;        
            ThreadPool.QueueUserWorkItem(helper.Method);
        }
    
        static void Execute(int number)
        {
            Console.WriteLine(" * NUM=" + number.ToString());
        }
    
        unsafe class Helper
        {
            public int* ints;
            
            public void Method(object state)            
            {
                Execute(ints[32]);
            }
        }    
    }
