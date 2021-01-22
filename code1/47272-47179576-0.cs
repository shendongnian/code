    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Threading;
    
    // Compiled and tested in: Visual Studio 2017, DotNET 4.6.1
    
    namespace MyNamespace
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                MyApplication app = new MyApplication();
                app.Run();
            }
        }
    
        public class MyApplication
        {
            private BlockingCollection<Job> JobQueue = new BlockingCollection<Job>();
            private CancellationTokenSource JobCancellationTokenSource = new CancellationTokenSource();
            private CancellationToken JobCancellationToken;
            private Timer Timer;
            private Thread UserInputThread;
    
    
    
            public void Run()
            {
                // Give a name to the main thread:
                Thread.CurrentThread.Name = "Main";
    
                // Fires a Timer thread:
                Timer = new Timer(new TimerCallback(TimerCallback), null, 1000, 2000);
    
                // Fires a thread to read user inputs:
                UserInputThread = new Thread(new ThreadStart(ReadUserInputs))
                {
                    Name = "UserInputs",
                    IsBackground = true
                };
                UserInputThread.Start();
    
                // Prepares a token to cancel the job queue:
                JobCancellationToken = JobCancellationTokenSource.Token;
    
                // Start processing jobs:
                ProcessJobs();
    
                // Clean up:
                JobQueue.Dispose();
                Timer.Dispose();
                UserInputThread.Abort();
    
                Console.WriteLine("Done.");
            }
    
    
    
            private void ProcessJobs()
            {
                try
                {
                    // Checks if the blocking collection is still up for dequeueing:
                    while (!JobQueue.IsCompleted)
                    {
                        // The following line blocks the thread until a job is available or throws an exception in case the token is cancelled:
                        JobQueue.Take(JobCancellationToken).Run();
                    }
                }
                catch { }
            }
    
    
    
            private void ReadUserInputs()
            {
                // User input thread is running here.
                ConsoleKey key = ConsoleKey.Enter;
    
                // Reads user inputs and queue them for processing until the escape key is pressed:
                while ((key = Console.ReadKey(true).Key) != ConsoleKey.Escape)
                {
                    Job userInputJob = new Job("UserInput", this, new Action<ConsoleKey>(ProcessUserInputs), key);
                    JobQueue.Add(userInputJob);
                }
                // Stops processing the JobQueue:
                JobCancellationTokenSource.Cancel();
            }
    
            private void ProcessUserInputs(ConsoleKey key)
            {
                // Main thread is running here.
                Console.WriteLine($"You just typed '{key}'. (Thread: {Thread.CurrentThread.Name})");
            }
    
    
    
            private void TimerCallback(object param)
            {
                // Timer thread is running here.
                Job job = new Job("TimerJob", this, new Action<string>(ProcessTimer), "A job from timer callback was processed.");
                JobQueue.TryAdd(job); // Just enqueues the job for later processing
            }
    
            private void ProcessTimer(string message)
            {
                // Main thread is running here.
                Console.WriteLine($"{message} (Thread: {Thread.CurrentThread.Name})");
            }
        }
    
    
    
        /// <summary>
        /// The Job class wraps an object's method call, with or without arguments. This method is called later, during the Job execution.
        /// </summary>
        public class Job
        {
            public string Name { get; }
            private object TargetObject;
            private Delegate TargetMethod;
            private object[] Arguments;
    
            public Job(string name, object obj, Delegate method, params object[] args)
            {
                Name = name;
                TargetObject = obj;
                TargetMethod = method;
                Arguments = args;
            }
    
            public void Run()
            {
                try
                {
                    TargetMethod.Method.Invoke(TargetObject, Arguments);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine($"Unexpected error running job '{Name}': {ex}");
                }
            }
    
        }
    }
