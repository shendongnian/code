    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.Threading;
    namespace ConsoleApplication1
    {
        class Program
        {
            static  List<Job> Queue = new List<Job>();
            const int TOTAL_JOB_COUNT = 100;
            const int TOTAL_WORKER_THREAD = 2;
            public static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            static void Main(string[] args)
            {
                for (int i = 0; i < TOTAL_JOB_COUNT; i++)
                {
                    Job newJob = new Job();
                    Object thisLock = new Object();
                    lock (thisLock)
                    {
                        Queue.Add(newJob);
                    }
                    newJob.state.id = i;
                    newJob.ProgressChanged += new ProgressChangedEventHandler(newJob_ProgressChanged);
                    newJob.DoWork +=new DoWorkEventHandler(newJob.doWork);
                    newJob.RunWorkerAsync();
                }
                manualResetEvent.WaitOne();
                Console.WriteLine("All jobs completed");
                Console.ReadLine();
            }
            static void newJob_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                Job job = sender as Job;
                State state = job.state;
                Console.WriteLine("Job Completed,  ID: '{0}', Results = '{1}'", state.id, state.Result);
                Object thisLock = new Object();
                {
                    for (int i = 0; i < Queue.Count; i++)
                    {
                        if (state.id == Queue[i].state.id)
                        {
                            Queue.RemoveAt(i);
                            break;
                        }
                    }
                    if (Queue.Count == 0) manualResetEvent.Set();
                }
            }
     
        }
        public class Job : BackgroundWorker
        {
            public State state = new State();
            public Job()
            {
                this.WorkerReportsProgress = true;
            }
            public void doWork(object sender, DoWorkEventArgs e)
            {
                Thread.Sleep(1000);
                state.Result = 123;
                this.ReportProgress(100, state);
                this.Dispose();
            }
        }
        public class State
        {
            public int id;
            public int Result { get; set; }
        }
    }
