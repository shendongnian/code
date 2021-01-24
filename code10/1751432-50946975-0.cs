    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.Threading;
    namespace ConsoleApplication51
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test test = new Test();
            }
        }
        public class Test
        {
            BackgroundWorker messageWorker = new BackgroundWorker();
            static AutoResetEvent autoEvent = new AutoResetEvent(false);
            List<int> Numbers = new List<int>() { 1,2,3,4,5};
            public Test()
            {
                messageWorker.DoWork += new DoWorkEventHandler(messageWorker_DoWork);
                ProcessBroadcast();
            }
            public void ProcessBroadcast()
            {
                foreach (int number in Numbers)
                {
                    //Send a Message here
                    autoEvent.Reset();
                    messageWorker.RunWorkerAsync(number);
                    autoEvent.WaitOne();
                }
            }
            private void messageWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                int? number = e.Argument as int?;
                BackgroundWorker worker = sender as BackgroundWorker;
                autoEvent.Set();
            }
     
        }
     
    }
