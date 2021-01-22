    class ThreadSafe
    {
        static List<string> list = new List<string>();
        static object obj=new object();
        static void Main()
        {
            var t1 = new Thread(AddItems);
            var t2 = new Thread(AddItems);
    
            t1.Start();
            t2.Start();
    
            t1.Join();
            t2.Join();
    
            foreach (string str in list)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("Count=" + list.Count.ToString());
            Console.ReadKey(true);
        }
        static void AddItems()
        {
            for (int i = 1; i < 10; i++)
                lock (obj)
                {
                    list.Add("Item " + i.ToString());
                }
        }
    }
