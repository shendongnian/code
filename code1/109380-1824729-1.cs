    using System;
    using System.Threading;
    namespace SmallConsoleAppForTests
    {
    class Program
    {
        private static AutoResetEvent[] events;
        static void Main(string[] args)
        {
            int dataLength = 3;
            // creating array of AutoResetEvent for signalling that the processing is done
            AutoResetEvent[] events = new AutoResetEvent[dataLength];
            // Initializing the AutoResetEvent array to "not-set" values;
            for (int i = 0; i < dataLength; i++)
                events[i] = new AutoResetEvent(false);
            //Processing the data
            for (int i = 0; i < dataLength; i++)
            {
                var data = new MyWorkItem { Event = events[i], Data = new MyDataClass() };
                ThreadPool.QueueUserWorkItem(x =>
                {
                    var workItem = (MyWorkItem)x;
                    try
                    {
                        // process the data
                    }
                    catch (Exception e)
                    {
                        //exception handling
                    }
                    finally
                    {
                        workItem.Event.Set();
                    }
                }, data);
            }
            //Wait untill all the threads finish
            WaitHandle.WaitAll(events);
        }
        
    }
    public class MyWorkItem
    {
        public AutoResetEvent Event { get; set; }
        public MyDataClass Data { get; set; }
    }
    // You can also use DataRow instead
    public class MyDataClass
    {
        //data
        //
    }
    }
