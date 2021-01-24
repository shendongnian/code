    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static object o;
            public static object[] array;
    
            static void Main(string[] args)
            {
                array = new object[10];
    
                for (int x = 0; x < array.Length; x++)
                    array[x] = new object();
    
                o = array[1];
                var tasks = new Task[100];
                Task t;
    
    
                //t = Task.Run(() => lockArray(5000));
                t = Task.Run(() => lockArrayIndex(5000));
                //t = Task.Run(() => lockObject(5000));
                for (int i = 0; i < tasks.Length; i++)
                {
                    //tasks[i] = Task.Run(() => lockArray(1000));
                    //tasks[i] = Task.Run(() => lockArrayIndex(1000));
                    tasks[i] = Task.Run(() => lockObject(1000));
                }
    
    
    
                Task.WaitAll(tasks);
    
                "done".Dump();
                Console.ReadKey();
            }
    
            private static void lockArray(int input)
            {
                //Lock on Array
                lock (array)
                {
                    System.Threading.Thread.Sleep(input);
                    "Array".Dump();
                }
            }
    
            private static void lockArrayIndex(int input)
            {
                //Lock on object of array
                lock (array[1])
                {
                    System.Threading.Thread.Sleep(input);
                    "Array[1]".Dump();
                }
            }
    
            private static void lockObject(int input)
            {
                //lock on another object
                lock (o)
                {
                    System.Threading.Thread.Sleep(input);
                    "o".Dump();
                }
            }
        }
    
        public static class extenstions
        {
            public static void Dump(this string input)
            {
                Console.WriteLine(input);
            }
        }
    }
