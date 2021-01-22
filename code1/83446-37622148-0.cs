    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace Test
    {
        class Program
        {
            //------------------------------------------------------------------------------  
            // Configuration.
    
            const bool Silent = true;
    
            const int Nb_Reading_Threads = 8;
            const int Nb_Writing_Threads = 8;
    
            //------------------------------------------------------------------------------  
            // Structured data.
    
            public class Data_Set
            {
                public const int Size = 20;
                public long[] T;
    
                public Data_Set(long t)
                {
                    T = new long[Size];
    
                    for (int i = 0; i < Size; i++)
                        T[i] = t;
                }
    
                public Data_Set(Data_Set DS)
                {
                    Set(DS);
                }
    
                public void Set(Data_Set DS)
                {
                    T = new long[Size];
    
                    for (int i = 0; i < Size; i++)
                        T[i] = DS.T[i];
                }
            }
    
            private static Data_Set Data_Sample = new Data_Set(9999);
    
            //------------------------------------------------------------------------------  
            // SAFE process.
    
            public enum Mode { Unsafe, Mutex, Slim };
            public static Mode Lock_Mode = Mode.Unsafe;
    
            private static readonly object Mutex_Lock = new object();
            private static readonly ReaderWriterLockSlim Slim_Lock = new ReaderWriterLockSlim();
    
            public static Data_Set Safe_Data
            {
                get
                {
                    switch (Lock_Mode)
                    {
                        case Mode.Mutex:
    
                            lock (Mutex_Lock)
                            {
                                return new Data_Set(Data_Sample);
                            }
    
                        case Mode.Slim:
    
                            Slim_Lock.EnterReadLock();
                            Data_Set DS = new Data_Set(Data_Sample);
                            Slim_Lock.ExitReadLock();
    
                            return DS;
    
                        default:
    
                            return new Data_Set(Data_Sample);
                    }
                }
                set
                {
                    switch (Lock_Mode)
                    {
                        case Mode.Mutex:
    
                            lock (Mutex_Lock)
                            {
                                Data_Sample.Set(value);
                            }
                            break;
    
                        case Mode.Slim:
    
                            Slim_Lock.EnterWriteLock();
                            Data_Sample.Set(value);
                            Slim_Lock.ExitWriteLock();
                            break;
    
                        default:
    
                            Data_Sample.Set(value);
                            break;
                    }
                }
            }
    
            //------------------------------------------------------------------------------  
            // Main function.
    
            static void Main(string[] args)
            {
                // Console.
                const int Columns = 120;
                const int Lines = (Silent ? 50 : 500);
    
                Console.SetBufferSize(Columns, Lines);
                Console.SetWindowSize(Columns, 40);
    
                // Threads.
                const int Nb_Threads = Nb_Reading_Threads + Nb_Writing_Threads;
                const int Max = (Silent ? 50000 : (Columns * (Lines - 5 - (3 * Nb_Threads))) / Nb_Threads);
    
                while (true)
                {
                    // Console.
                    Console.Clear();
                    Console.WriteLine("");
    
                    switch (Lock_Mode)
                    {
                        case Mode.Mutex:
    
                            Console.WriteLine("---------- Mutex ----------");
                            break;
    
                        case Mode.Slim:
    
                            Console.WriteLine("---------- Slim ----------");
                            break;
    
                        default:
    
                            Console.WriteLine("---------- Unsafe ----------");
                            break;
                    }
    
                    Console.WriteLine("");
                    Console.WriteLine(Nb_Reading_Threads + " reading threads + " + Nb_Writing_Threads + " writing threads");
                    Console.WriteLine("");
    
                    // Flags to monitor all threads.
                    bool[] Completed = new bool[Nb_Threads];
    
                    for (int i = 0; i < Nb_Threads; i++)
                        Completed[i] = false;
    
                    // Threads that change the values.
                    for (int W = 0; W < Nb_Writing_Threads; W++)
                    {
                        var Writing_Thread = new Thread((state) =>
                        {
                            int t = (int)state;
                            int u = t % 10;
    
                            Data_Set DS = new Data_Set(t + 1);
    
                            try
                            {
                                for (int k = 0; k < Max; k++)
                                {
                                    Safe_Data = DS;
    
                                    if (!Silent) Console.Write(u);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("\r\n" + "Writing thread " + (t + 1) + " / " + ex.Message + "\r\n");
                            }
    
                            Completed[Nb_Reading_Threads + t] = true;
                        });
    
                        Writing_Thread.Start(W);
                    }
    
                    // Threads that read the values.
                    for (int R = 0; R < Nb_Reading_Threads; R++)
                    {
                        var Reading_Thread = new Thread((state) =>
                        {
                            int t = (int)state;
                            char u = (char)((int)('A') + (t % 10));
    
                            try
                            {
                                for (int j = 0; j < Max; j++)
                                {
                                    Data_Set DS = Safe_Data;
    
                                    for (int i = 0; i < Data_Set.Size; i++)
                                    {
                                        if (DS.T[i] != DS.T[0])
                                        {
                                            string Log = "";
    
                                            for (int k = 0; k < Data_Set.Size; k++)
                                                Log += DS.T[k] + " ";
    
                                            throw new Exception("Iteration " + (i + 1) + "\r\n" + Log);
                                        }
                                    }
    
                                    if (!Silent) Console.Write(u);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("\r\n" + "Reading thread " + (t + 1) + " / " + ex.Message + "\r\n");
                            }
    
                            Completed[t] = true;
                        });
    
                        Reading_Thread.Start(R);
                    }
    
                    // Wait for all threads to complete.
                    bool All_Completed = false;
    
                    while (!All_Completed)
                    {
                        All_Completed = true;
    
                        for (int i = 0; i < Nb_Threads; i++)
                            All_Completed &= Completed[i];
                    }
    
                    // END.
                    Console.WriteLine("");
                    Console.WriteLine("Done!");
                    Console.ReadLine();
                    
                    // Toogle mode.
                    switch (Lock_Mode)
                    {
                        case Mode.Unsafe:
    
                            Lock_Mode = Mode.Mutex;
                            break;
    
                        case Mode.Mutex:
    
                            Lock_Mode = Mode.Slim;
                            break;
    
                        case Mode.Slim:
    
                            Lock_Mode = Mode.Unsafe;
                            break;
                    }
                }
            }
        }
    }
