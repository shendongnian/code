    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace TaskQueueExample
    {
    class Program
    {
        public class TaskState
        {
            private static int _taskCounter = 0;
            public int TaskId { get; set;  }
            public int Delay { get; set; }
            public int Workload { get; set; }
            public CancellationToken CancellationToken { get; set; }
            public TaskState()
            {
                TaskId = _taskCounter;
                _taskCounter++;
            }
        }
        static CancellationTokenSource _cts = new CancellationTokenSource();
        static Random _rand = new Random();
        static void Main(string[] args)
        {
            var state = new TaskState() { Delay = _rand.Next(0, 1000), Workload= _rand.Next(0, 1000), CancellationToken = _cts.Token };
            
            Task.Factory.StartNew(Program.DoSomeWork, state, _cts.Token).ContinueWith(Program.OnWorkComplete);
                        
            Console.WriteLine("Tasks will start running in the background. Press enter at any time to exit.");
            Console.ReadLine();
            _cts.Cancel();
        }
        static void DoSomeWork(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            var state = (TaskState)obj;
            Console.WriteLine("Delaying execution of Task {0} for {1} [ms]", state.TaskId, state.Delay);
            
            state.CancellationToken.ThrowIfCancellationRequested();
            // Delay execution, while monitoring for cancellation
            // If Task.Delay isn't responsive enough, use something like this.
            var sw = Stopwatch.StartNew();
            while(sw.Elapsed.TotalMilliseconds < state.Delay)
            {
                Thread.Yield(); // don't hog the CPU
                state.CancellationToken.ThrowIfCancellationRequested();
            }
            Console.WriteLine("Beginning to process workload of Task {0}", state.TaskId);
            // Simulate a workload (NOTE: no Thread.Yield())
            sw.Restart();
            while(sw.Elapsed.TotalMilliseconds < state.Workload)
            {                
                state.CancellationToken.ThrowIfCancellationRequested();
            }           
        }
        static void OnWorkComplete(Task parent)
        {
            var state = (TaskState)parent.AsyncState;
            try
            {
                parent.Wait();
                Console.WriteLine("Task {0} successfully completed processing it's workload without error.", state.TaskId);
            }
            catch(TaskCanceledException)
            {
                Console.WriteLine("The Task {0} was successfully cancelled.", parent.AsyncState);
                // since it was cancelled, just return. No need to continue spawning new tasks.
                return;
            }
            catch(Exception ex)
            {
                Console.WriteLine("An unexpected exception brought Task {0} down. {1}", state.TaskId, ex.Message);
            }
            // Kick off another task...
            var child_state = new TaskState() { Delay = _rand.Next(0, 1000), Workload = _rand.Next(0, 1000), CancellationToken = _cts.Token };
            Task.Factory.StartNew(Program.DoSomeWork, child_state, _cts.Token).ContinueWith(Program.OnWorkComplete);
        }
    }
    }
