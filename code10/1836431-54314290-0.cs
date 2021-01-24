        using System;
        using System.Collections;
        using System.Collections.Concurrent;
        using System.Collections.Generic;
        using System.Linq;
        using System.Reactive;
        using System.Reactive.Linq;
        using System.Reactive.Subjects;
        using System.Threading.Tasks;
        
        namespace test
        {
            class Program
            {
                class WorkItem
                {
                    public int Id { get; set; } // you can make it store more things
                    public TaskCompletionSource<DateTime> TaskSource { get; } = new TaskCompletionSource<DateTime>();
                }
        
                class Worker : IDisposable
                {
                    private BlockingCollection<WorkItem> _queue;
                    private Task _consumer;
        
                    public Worker()
                    {
                        _queue = new BlockingCollection<WorkItem>();
        
                        _consumer = Task.Run(async () =>
                        {
                            foreach (var item in _queue.GetConsumingEnumerable())
                            {
                                await Task.Delay(1000); // some hard work
                                item.TaskSource.TrySetResult(DateTime.Now); // try is safer
    // you can return whatever you want
                            }
                        });
                    }
        
                    public Task<DateTime> DoWork(int i) // return whatever you want
                    {
                        var workItem = new WorkItem { Id = i };
                        _queue.Add(workItem);
        
                        return workItem.TaskSource.Task;
                    }
                    public void Dispose()
                    {
                        _queue.CompleteAdding();
                    }
                }
        
                public static void Main(string[] args)
                {
                    using (var worker = new Worker())
                    {
                        Task.Run(async () =>
                        {
                            var tasks = Enumerable.Range(0,10).Select(x => worker.DoWork(x)).ToArray();
        
                            var time = await tasks[1];
                            Console.WriteLine("2nd task finished at " + time);
        
                            foreach (var task in tasks)
                            {
                                time = await task;
                                Console.WriteLine("Task finished at " + time);
                            }
        
                            Console.ReadLine();
                        }).Wait();
                    }
        
        
        
                }
            }
        }
        // output
        2nd task finished at 2019-01-22 19:14:57
        Task finished at 2019-01-22 19:14:56
        Task finished at 2019-01-22 19:14:57
        Task finished at 2019-01-22 19:14:58
        Task finished at 2019-01-22 19:14:59
        Task finished at 2019-01-22 19:15:00
        Task finished at 2019-01-22 19:15:01
        Task finished at 2019-01-22 19:15:02
        Task finished at 2019-01-22 19:15:03
        Task finished at 2019-01-22 19:15:04
        Task finished at 2019-01-22 19:15:05
