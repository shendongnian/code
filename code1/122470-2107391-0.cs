    using System;
    using System.Threading;
    class Program
    {
        static void Main(string[] args)
        {
            //    create the reset event -- initially unsignalled
            var resetEvent = new ManualResetEvent(false);
            //    information will be filled by another thread
            string information = null;
    
            //    the other thread to run
            Action infoGet = delegate
            {
                //    get the information
                information = Console.ReadLine();
                //    signal the event because we're done
                resetEvent.Set();
            };
    
            //    call the action in a seperate thread
            infoGet.BeginInvoke(null, null);
            //    wait for completion
            resetEvent.WaitOne();
            //    write out the information
            Console.WriteLine(information);
        }
    }
