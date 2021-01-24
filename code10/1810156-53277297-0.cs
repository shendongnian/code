    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp10
    {
        class Program
        {
            static void Main()
            {
                Barrier barrier = new Barrier(participantCount:4);
                for (int i = 0; i < 3; ++i)
                {
                    int index = i;
                    Task.Run(() => test(barrier, index));
                }
                Console.WriteLine("Outer thread waiting at barrier.");
                barrier.SignalAndWait();
                Console.WriteLine("Outer thread passed barrier.");
                Console.ReadLine();
            }
            static void test(Barrier barrier, int index)
            {
                Console.WriteLine($"Thread {index} sleeping.");
                Thread.Sleep(index * 1000);
                Console.WriteLine($"Thread {index} waiting at barrier.");
                barrier.SignalAndWait();
                Console.WriteLine($"Thread {index} passed the barrier.");
            }
        }
    }
