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
            static AutoResetEvent block = new AutoResetEvent(false);
            static void Main(string[] args)
            {
                block.Reset();
                Test test = new Test();
                block.WaitOne();
            }
        }
        public class State
        {
            public string messsage = "";
        }
        public class Test
        {
            BackgroundWorker messageWorker = new BackgroundWorker();
            
            static AutoResetEvent autoEvent = new AutoResetEvent(false);
            List<int> Numbers = new List<int>() { 1,2,3,4,5};
            public Test()
            {
                messageWorker.DoWork += new DoWorkEventHandler(messageWorker_DoWork);
                messageWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(messageWorker_RunWorkerCompleted);
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
                State state = new State() { messsage = "Done"};
               
            }
            private void messageWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                autoEvent.Set();
            }
     
        }
     
    }
