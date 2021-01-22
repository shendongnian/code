    class Program
    {
        static public List<int> temp = new List<int >();
        static public List<Thread> worker = new List<Thread>();
        static public List<List<int>> temporary = new List<List<int>>();
        static public object sync = new object();
        
        static void Main(string[] args)
        {
            temp.add(20);
            temp.add(10);
            temp.add(5);
            
            // Add a corresponding number of lists
            for( int i = 0; i < temp.Count; ++i)
            {
                temporary.Add(new List<int>);
            }
            
            // As Jon Skeet mentioned, z must be declared outside the for loop
            int z = 0;
            foreach (int k in temp)
            {
                // As Jon Skeet mentioned, you need to capture the value of k
                int copy = k;
                
                Thread t = new Thread(() => { Sample(copy, z); });
                t.Name = "Worker" + z.ToString();
                
                // set the thread to background, so your thread is 
                // properly closed when your application closes.
                t.IsBackground = true; 
                t.Start();
                
                // Calling worker[z] will always going to be out of bounds
                // because you didn't add anything to to the worker list,
                // therefore you just need to add the thread to the worker
                // list. Note that you're not doing anything with the worker
                // list, so you might as well not have it at all.
                worker.Add(t);
                z++;
            }
        }
        
        // Supply the order of your array
        public static void Sample(int n, int order)
        { 
            for (int i = 0; i < n; i++)
            {
                // Technically in this particular case you don't need to 
                // synchronize, but it doesn't hurt to know how to do it.
                lock(sync)
                {
                    temporary[order].Add(i);
                }
            }
    }
