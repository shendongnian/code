    using System;
    using System.Collections.Generic;
    using System.Threading;
    namespace SO_ThreadSafeQueue
    {
        class Program
        {
            static int _QueueExceptions;
            static int _QueueNull;
            static int _QueueProcessed;
            static int _ThreadSafeQueueExceptions;
            static int _ThreadSafeQueueNull;
            static int _ThreadSafeQueueProcessed;
            static readonly Queue<Guid?> _Queue = new Queue<Guid?>();
            static readonly ThreadSafeQueue<Guid?> _ThreadSafeQueue = new ThreadSafeQueue<Guid?>();
            static readonly Random _Random = new Random();
            const int Expected = 10000000;
            static void Main()
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Creating queues...");
                for (int i = 0; i < Expected; i++)
                {
                    Guid guid = Guid.NewGuid();
                    _Queue.Enqueue(guid);
                    _ThreadSafeQueue.Enqueue(guid);
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Processing queues...");
                for (int i = 0; i < 100; i++)
                {
                    ThreadPool.QueueUserWorkItem(ProcessQueue);
                    ThreadPool.QueueUserWorkItem(ProcessThreadSafeQueue);
                }
                int progress = 0;
                while (_Queue.Count > 0 || _ThreadSafeQueue.Count > 0)
                {
                    Console.SetCursorPosition(0, 0);
                    switch (progress)
                    {
                        case 0:
                            {
                                Console.WriteLine("Processing queues... |");
                                progress = 1;
                                break;
                            }
                        case 1:
                            {
                                Console.WriteLine("Processing queues... /");
                                progress = 2;
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Processing queues... -");
                                progress = 3;
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Processing queues... \\");
                                progress = 0;
                                break;
                            }
                    }
                    Thread.Sleep(200);
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Finished processing queues...");
                Console.WriteLine("\r\nQueue Count:           {0} Processed: {1, " + Expected.ToString().Length + "} Exceptions: {2,4} Null: {3}", _Queue.Count, _QueueProcessed, _QueueExceptions, _QueueNull);
                Console.WriteLine("ThreadSafeQueue Count: {0} Processed: {1, " + Expected.ToString().Length + "} Exceptions: {2,4} Null: {3}", _ThreadSafeQueue.Count, _ThreadSafeQueueProcessed, _ThreadSafeQueueExceptions, _ThreadSafeQueueNull);
                Console.WriteLine("\r\nPress any key...");
                Console.ReadKey();
            }
            static void ProcessQueue(object nothing)
            {
                while (_Queue.Count > 0)
                {
                    Guid? currentItem = null;
                    try
                    {
                        currentItem = _Queue.Dequeue();
                    }
                    catch (Exception)
                    {
                        Interlocked.Increment(ref _QueueExceptions);
                    }
                    if (currentItem != null)
                    {
                        Interlocked.Increment(ref _QueueProcessed);
                    }
                    else
                    {
                        Interlocked.Increment(ref _QueueNull);
                    }
                    Thread.Sleep(_Random.Next(1, 10)); // Simulate different workload times
                }
            }
            static void ProcessThreadSafeQueue(object nothing)
            {
                while (_ThreadSafeQueue.Count > 0)
                {
                    Guid? currentItem = null;
                    try
                    {
                        currentItem = _ThreadSafeQueue.Dequeue();
                    }
                    catch (Exception)
                    {
                        Interlocked.Increment(ref _ThreadSafeQueueExceptions);
                    }
                    if (currentItem != null)
                    {
                        Interlocked.Increment(ref _ThreadSafeQueueProcessed);
                    }
                    else
                    {
                        Interlocked.Increment(ref _ThreadSafeQueueNull);
                    }
                    Thread.Sleep(_Random.Next(1, 10)); // Simulate different workload times
                }
            }
            /// <summary>
            /// Represents a thread safe <see cref="Queue{T}"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class ThreadSafeQueue<T> : Queue<T>
            {
                #region Private Fields
                private readonly object _LockObject = new object();
                #endregion
                #region Public Properties
                /// <summary>
                /// Gets the number of elements contained in the <see cref="ThreadSafeQueue{T}"/>
                /// </summary>
                public new int Count
                {
                    get
                    {
                        int returnValue;
                        lock (_LockObject)
                        {
                            returnValue = base.Count;
                        }
                        return returnValue;
                    }
                }
                #endregion
                #region Public Methods
                /// <summary>
                /// Removes all objects from the <see cref="ThreadSafeQueue{T}"/>
                /// </summary>
                public new void Clear()
                {
                    lock (_LockObject)
                    {
                        base.Clear();
                    }
                }
                /// <summary>
                /// Removes and returns the object at the beggining of the <see cref="ThreadSafeQueue{T}"/>
                /// </summary>
                /// <returns></returns>
                public new T Dequeue()
                {
                    T returnValue;
                    lock (_LockObject)
                    {
                        returnValue = base.Dequeue();
                    }
                    return returnValue;
                }
                /// <summary>
                /// Adds an object to the end of the <see cref="ThreadSafeQueue{T}"/>
                /// </summary>
                /// <param name="item">The object to add to the <see cref="ThreadSafeQueue{T}"/></param>
                public new void Enqueue(T item)
                {
                    lock (_LockObject)
                    {
                        base.Enqueue(item);
                    }
                }
                /// <summary>
                /// Set the capacity to the actual number of elements in the <see cref="ThreadSafeQueue{T}"/>, if that number is less than 90 percent of current capactity.
                /// </summary>
                public new void TrimExcess()
                {
                    lock (_LockObject)
                    {
                        base.TrimExcess();
                    }
                }
                #endregion
            }
        }
    }
