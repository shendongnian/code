    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using System.Threading;
    using System.Diagnostics;
    
    namespace B_0003_RandomSpeedTest
    {
        class WorkItem
        {
    		//=-------------------------------------------------------------------
            string ThreadName = string.Empty;
    
            static int ListArrayCount = 20;
            static int ArrayLength = 1000;
    
            static int[] SharedData = new int[ArrayLength];
            static List<int[]> ListOfIntArrays = new List<int[]>();
    
    		//=-------------------------------------------------------------------
            public WorkItem(string threadName)
            {
                ThreadName = threadName;
    
            }
    		//=-------------------------------------------------------------------	
            public static void Initialize()
            {
    
                for (int i = 0; i < SharedData.Length; i++)
                {
                    SharedData[i] = i * 23;
                }
    
                for (int j = 0; j < ListArrayCount; j++)
                {
                    int[] fillArray = new int[ArrayLength];
                    for (int i = 0; i < SharedData.Length; i++)
                    {
                        fillArray[i] = i * 23;
                    }
                    ListOfIntArrays.Add(fillArray);
                }
            }
    		//=-------------------------------------------------------------------
            public void DoStuff()
            {
                int loops = 100000000;
                int multiplier = 2;
    
                ulong xtraLong = 0;
    
    
                RandomNumbers.ReInitialize();
    
                int randArrayNum = RandomNumbers.RandomInt(0, ListOfIntArrays.Count - 1);
    
                Console.WriteLine("Random Array : {0}", randArrayNum);
                int[] SharedDataFromList = ListOfIntArrays[randArrayNum];
    
                int[] localSharedData = new int[ArrayLength];
                for (int i = 0; i < SharedData.Length; i++)
                {
                    localSharedData[i] = SharedData[i];
                }
    
                Console.WriteLine(ThreadName + " Begin...");
                for (int j = 0; j < multiplier; j++)
                {
    
                    TAMagic.Utilities.RandomNumbers.ReInitialize();
                    for (int i = 1; i < loops; i++)
                    {
                        int RandInt = RandomNumbers.RandomInt(0, SharedDataFromList.Length - 1);
                        int justANumber = SharedDataFromList[RandInt];
    
                        if (xtraLong > ulong.MaxValue - 10000)
                        {
                            xtraLong = xtraLong / 2;
                        }
    
                        xtraLong += (ulong)(justANumber);
                    }
                }
                Console.WriteLine(ThreadName + " Finished... total : {0,22:N0}", xtraLong);
            }
    		//=-------------------------------------------------------------------
        }
    	public static class RandomNumbers // TAMagic.Utilities.RandomNumbers
        {
    		//[ThreadStatic]
            private static Random random = new Random();
    		//=-------------------------------------------------------------------
    		public static void ReInitialize()
            {
    
                random = new Random();
            }
    		//=-------------------------------------------------------------------
            // number between the min and the max number
            public static int RandomInt(int min, int max) 
            {
                
                return random.Next(min, max + 1);
            }
    		//=-------------------------------------------------------------------
    	}
        class Program
        {
            static void Main(string[] args)
            {
                Stopwatch sw = new Stopwatch();
    
                int threadCount = 4; // thread count, set to number of cores in your machine
    
                long SingleThreadMultipliedOut = 0;
                long ThreadVersion = 0;
                long TaskVersion = 0;
    
                Console.WriteLine("");
    
                Console.WriteLine("Thread Count {0} \n\n", threadCount);
    
                WorkItem.Initialize();
    
                //=--------------------------------------------------------------
    
                //Console.WriteLine("BEGIN loop");
                //sw.Start();
                //for (int i = 0; i < threadCount; i++)
                //{
                //    WorkItem thr = new WorkItem(i.ToString());
                //    thr.DoStuff();
                //}
                //sw.Stop();
                //Console.WriteLine("sw.ElapsedMilliseconds {0}", sw.ElapsedMilliseconds);
                //Console.WriteLine("END loop\n\n");
    
                //=------ Since the above takes so long estimate it, to see how long this would take on a single core. 
    
                Console.WriteLine("BEGIN loop");
                sw.Start();
                WorkItem thr = new WorkItem("Single ");
                thr.DoStuff();
                sw.Stop();
                SingleThreadMultipliedOut = sw.ElapsedMilliseconds * threadCount;
                Console.WriteLine("sw.Seconds {0,22:#,#.###}", SingleThreadMultipliedOut / 1000);
                Console.WriteLine("END loop\n\n");
    
    
    
                Thread[] t = new Thread[threadCount];
                Task[] ta = new Task[threadCount];
                WorkItem[] at = new WorkItem[threadCount];
                //=--------------------------------------------------------------
                sw.Reset();
                sw.Start();
                Console.WriteLine("BEGIN Tasks");
    
                at = new WorkItem[threadCount];
    
                for (int i = 0; i < threadCount; i++)
                {
                    //System.Threading.Thread.Sleep(100);
                    WorkItem thrx = new WorkItem(i.ToString());
                    at[i] = thrx;
                    ta[i] = new Task(at[i].DoStuff);
                }
    
                for (int i = 0; i < threadCount; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    ta[i].Start();
                }
    
                while (ta.Any(tx => !tx.IsCompleted)) { } //spin wait
    
                sw.Stop();
                TaskVersion = sw.ElapsedMilliseconds;
                Console.WriteLine("sw.Seconds {0,22:#,#.###}", TaskVersion / 1000);
                Console.WriteLine("END Tasks\n\n");
                //=--------------------------------------------------------------
    
                System.Threading.Thread.Sleep(10000); // sleep for 10 seconds and let the app recover all the resources
                sw.Reset();
    			
                sw.Start();
                Console.WriteLine("BEGIN Threads");
    
                for (int i = 0; i < threadCount; i++)
                {
                    //System.Threading.Thread.Sleep(100);
                    WorkItem thrx = new WorkItem(i.ToString());
                    at[i] = thrx;
                    t[i] = new Thread(new ThreadStart(at[i].DoStuff));
                }
    
                for (int i = 0; i < threadCount; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    t[i].Start();
                }
    
                while (t.Any(tx => tx.IsAlive)) { } //spin wait - t[0].IsAlive
    
                sw.Stop();
                ThreadVersion = sw.ElapsedMilliseconds;
                Console.WriteLine("sw.Seconds {0,22:#,#.###}", ThreadVersion / 1000);
                Console.WriteLine("END Threads\n\n");
                //=--------------------------------------------------------------
    
                Console.WriteLine("\n\nThread Count {0}", threadCount);
                Console.WriteLine("SingleThreadMultipliedOut  sw.Seconds {0,22:#,#.###}", SingleThreadMultipliedOut / 1000);
                Console.WriteLine("ThreadVersion              sw.Seconds {0,22:#,#.###}", ThreadVersion / 1000);
                Console.WriteLine("TaskVersion                sw.Seconds {0,22:#,#.###}", TaskVersion / 1000);
                Console.WriteLine("\n\n");
                //=--------------------------------------------------------------
    
                Console.WriteLine("Hit Enter To Exit");
                Console.ReadLine();
            }
        }
    }
