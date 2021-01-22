    using System;
    using System.Runtime.Remoting.Messaging;
    using System.Threading;
    class Program
    {
        static void Main(string[] args)
        {
            Main m = new Main();
            m.TestMRE();
            Console.ReadKey();
            
        }
    }
    class Main
    {
        CalHandler handler = new CalHandler();
        int numberofTasks =0;
        public void TestMRE()
        {
            for (int j = 0; j <= 3; j++)
            {
                Console.WriteLine("Outer Loop is :" + j.ToString());
                ManualResetEvent signal = new ManualResetEvent(false);
                numberofTasks = 4;
                for (int i = 0; i <= 3; i++)
                {
                    CalHandler.count caller = new CalHandler.count(handler.messageHandler);
                    caller.BeginInvoke(i, new AsyncCallback(NumberCallback),signal);
                }
                signal.WaitOne();
            }
        }
        private void NumberCallback(IAsyncResult result)
        {
            AsyncResult asyncResult = (AsyncResult)result;
            CalHandler.count caller = (CalHandler.count)asyncResult.AsyncDelegate;
            int num = caller.EndInvoke(asyncResult);
            Console.WriteLine("Number is :"+ num.ToString());
          
            ManualResetEvent mre = (ManualResetEvent)asyncResult.AsyncState;
            if (Interlocked.Decrement(ref numberofTasks) == 0)
            {
                mre.Set();
            }
        }
    
    }
    public class CalHandler
    {
        public delegate int count(int number);
        public int messageHandler ( int number )
        {
            return number;
        }
    
    }
  
