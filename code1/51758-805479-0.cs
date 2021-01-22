    using System.Threading;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    
    namespace Test {
    
        static class RWLSExtension {
            struct Disposable : IDisposable {
                readonly Action _action;
                public Disposable(Action action) {
                    _action = action;
                }
                public void Dispose() {
                    _action();
                }
            }
    
            public static IDisposable ReadLock(this ReaderWriterLockSlim rwls) {
                rwls.EnterReadLock();
                return new Disposable(rwls.ExitReadLock);
            }
            public static IDisposable UpgradableReadLock(this ReaderWriterLockSlim rwls) {
                rwls.EnterUpgradeableReadLock();
                return new Disposable(rwls.ExitUpgradeableReadLock);
            }
            public static IDisposable WriteLock(this ReaderWriterLockSlim rwls) {
                rwls.EnterWriteLock();
                return new Disposable(rwls.ExitWriteLock);
            }
        }
    
        class SlowList<T> {
    
            List<T> baseList = new List<T>();
    
            public void AddRange(IEnumerable<T> items) {
                baseList.AddRange(items);
            }
    
            public virtual T this[int index] {
                get {
                    Thread.Sleep(1);
                    return baseList[index];
                }
                set {
                    baseList[index] = value;
                    Thread.Sleep(1);
                }
            }
        }
    
        class SynchronizedList<T> : SlowList<T> {
    
            object sync = new object();
    
            public override T this[int index] {
                get {
                    lock (sync) {
                        return base[index];
                    }
    
                }
                set {
                    lock (sync) {
                        base[index] = value;
                    }
                }
            }
        }
    
    
        class ManualReaderWriterLockedList<T> : SlowList<T> {
    
            ReaderWriterLockSlim slimLock = new ReaderWriterLockSlim();
    
            public override T this[int index] {
                get {
                    T item;
                    try {
                        slimLock.EnterReadLock();
                        item = base[index];
                    } finally {
                        slimLock.ExitReadLock();
                    }
                    return item;
    
                }
                set {
                    try {
                        slimLock.EnterReadLock();
                        base[index] = value;
                    } finally {
                        slimLock.ExitReadLock();
                    }
                }
            }
        }
    
        class ReaderWriterLockedList<T> : SlowList<T> {
    
            ReaderWriterLockSlim slimLock = new ReaderWriterLockSlim();
    
            public override T this[int index] {
                get {
                    using (slimLock.ReadLock()) {
                        return base[index];
                    }
                }
                set {
                    using (slimLock.WriteLock()) {
                        base[index] = value;
                    }
                }
            }
        }
    
    
        class Program {
    
    
            private static void Repeat(int times, int asyncThreads, Action action) {
                if (asyncThreads > 0) {
    
                    var threads = new List<Thread>();
    
                    for (int i = 0; i < asyncThreads; i++) {
    
                        int iterations = times / asyncThreads;
                        if (i == 0) {
                            iterations += times % asyncThreads;
                        }
    
                        Thread thread = new Thread(new ThreadStart(() => Repeat(iterations, 0, action)));
                        thread.Start();
                        threads.Add(thread);
                    }
    
                    foreach (var thread in threads) {
                        thread.Join();
                    }
    
                } else {
                    for (int i = 0; i < times; i++) {
                        action();
                    }
                }
            }
    
            static void TimeAction(string description, Action func) {
                var watch = new Stopwatch();
                watch.Start();
                func();
                watch.Stop();
                Console.Write(description);
                Console.WriteLine(" Time Elapsed {0} ms", watch.ElapsedMilliseconds);
            }
    
            static void Main(string[] args) {
    
                int threadCount = 40;
                int iterations = 200;
                int readToWriteRatio = 60;
    
                var baseList = Enumerable.Range(0, 10000).ToList();
    
                List<SlowList<int>> lists = new List<SlowList<int>>() {
                    new SynchronizedList<int>() ,
                    new ReaderWriterLockedList<int>(),
                    new ManualReaderWriterLockedList<int>()
                };
    
                foreach (var list in lists) {
                    list.AddRange(baseList);
                }
    
    
                foreach (var list in lists) {
                    TimeAction("Time for " + list.GetType().ToString(), () =>
                    {
                        Repeat(iterations, threadCount, () =>
                        {
                            list[100] = 99;
                            for (int i = 0; i < readToWriteRatio; i++) {
                                int ignore = list[i];
                            }
                        });
                    });
                }
                
                
    
                Console.WriteLine("DONE");
                Console.ReadLine();
            }
        }
    }
