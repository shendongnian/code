    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static System.Console;
    namespace ConsoleApp1
    {
        class Program
        {
            public const int MaxNumberOfTasks = 10;
            private static readonly Random Random = new Random();
    
            static void Main(string[] args)
            {
                var workers = new List<IWorker>(MaxNumberOfTasks);
    
                for (var i = 0; i < MaxNumberOfTasks; i++)
                    workers.Add(GetRandomWorker());
    
                WriteLine("Random Priority Workers\n");
                RunWorkersAsync(workers).Wait();
    
                WriteLine("\nSet Priority Workers\n");
                RunWorkersByPriorityAsync(workers).Wait();
    
                WriteLine("\nWork Complete\n");
                Read();
            }
    
            private static async Task RunWorkersAsync(List<IWorker> workers)
            {
                foreach (var worker in workers)
                    await worker.DoWork();
            }
    
            private static async Task RunWorkersByPriorityAsync(List<IWorker> workers)
            {
                var highWorkers = new List<IWorker>();
                var mediumWorkers = new List<IWorker>();
                var lowWorkers = new List<IWorker>();
    
                foreach (var worker in workers)
                {
                    var priorityAttribute = (PriorityAttribute)worker.GetType().GetCustomAttributes(typeof(PriorityAttribute), false).FirstOrDefault();
                    if (priorityAttribute != null)
                    {
                        switch (priorityAttribute.Priority)
                        {
                            case Priority.High:
                                highWorkers.Add(worker);
                                break;
                            case Priority.Medium:
                                mediumWorkers.Add(worker);
                                break;
                            case Priority.Low:
                            default:
                                lowWorkers.Add(worker);
                                break;
                        }
                    }
                    else
                    {
                        lowWorkers.Add(worker);
                    }
                }
    
                await RunWorkersAsync(highWorkers);
                await RunWorkersAsync(mediumWorkers);
                await RunWorkersAsync(lowWorkers);
            }
    
            private static IWorker GetRandomWorker()
            {
                var randomNumber = Random.Next(0, 3);
                switch (randomNumber)
                {
                    case 0:
                        return new HighLevelWorker();
                    case 1:
                        return new MediumLevelWorker();
                    case 2:
                    default:
                        return new LowLevelWorker();
                }
            }
        }
    
        public interface IWorker
        {
            Task DoWork();
        }
    
        [AttributeUsage(AttributeTargets.Class)]
        public class PriorityAttribute : Attribute
        {
            public PriorityAttribute(Priority priority) => Priority = priority;
            public Priority Priority { get; }
        }
    
        public enum Priority
        {
            Low,
            Medium,
            High
        }
    
        [Priority(Priority.High)]
        public class HighLevelWorker : IWorker
        {
            public async Task DoWork()
            {
                await Task.Delay(200);
                WriteLine($"{nameof(HighLevelWorker)} complete.");
            }
        }
    
        [Priority(Priority.Medium)]
        public class MediumLevelWorker : IWorker
        {
            public async Task DoWork()
            {
                await Task.Delay(200);
                WriteLine($"{nameof(MediumLevelWorker)} complete.");
            }
        }
    
        [Priority(Priority.Low)]
        public class LowLevelWorker : IWorker
        {
            public async Task DoWork()
            {
                await Task.Delay(200);
                WriteLine($"{nameof(LowLevelWorker)} complete.");
            }
        }
    }
