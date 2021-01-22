    class Test
    {
        static void Main()
        {
    	//STEP 1: Create a wait handle
            ManualResetEvent[] events = new ManualResetEvent[10];//Create a wait handle
            for (int i=0; i < events.Length; i++)
            {
                events[i] = new ManualResetEvent(false);
                Runner r = new Runner(events[i], i); 
                new Thread(new ThreadStart(r.Run)).Start();
            }
            
    	//STEP 2: Register for the events to wait for
            int index = WaitHandle.WaitAny(events); //wait here for any event and print following line.
            
            Console.WriteLine ("***** The winner is {0} *****", 
                               index);
            
            WaitHandle.WaitAll(events); //Wait for all of the threads to finish, that is, to call their cooresponding `.Set()` method.
    
            Console.WriteLine ("All finished!");
        }
    }
    class Runner
    {
        static readonly object rngLock = new object();
        static Random rng = new Random();
        
        ManualResetEvent ev;
        int id;
        
        internal Runner (ManualResetEvent ev, int id)
        {
            this.ev = ev;//Wait handle associated to each object, thread in this case.
            this.id = id;
        }
        
        internal void Run()
        {
    	//STEP 3: Do some work
            for (int i=0; i < 10; i++)
            {
                int sleepTime;
                // Not sure about the thread safety of Random...
                lock (rngLock)
                {
                    sleepTime = rng.Next(2000);
                }
                Thread.Sleep(sleepTime);
                Console.WriteLine ("Runner {0} at stage {1}",
                                   id, i);
            }
    
    	//STEP 4: Im done!
            ev.Set();
        }
    }
