    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ValueFactoryBehavingBadlyExample
    {
        class Program
        {
            static ConcurrentDictionary<int, int> m_Dict = new ConcurrentDictionary<int, int>();
            static ManualResetEventSlim m_MRES = new ManualResetEventSlim(false);
            static void Main(string[] args)
            {
                for (int i = 0; i < 8; ++i)
                {
                    Task.Factory.StartNew(ThreadGate, TaskCreationOptions.LongRunning);
                }
                Thread.Sleep(1000);
                m_MRES.Set();
                Thread.Sleep(1000);
                Console.WriteLine("Dictionary Size: " + m_Dict.Count);
                Console.Read();
            }
    
            static void ThreadGate()
            {
                m_MRES.Wait();
                int value = m_Dict.GetOrAdd(0, ValueFactory);
            }
    
            static int ValueFactory(int key)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Value Factory Called");
                return key;
            }
        }
    }
    
