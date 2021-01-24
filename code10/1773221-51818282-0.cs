        public static void Main(string[] args)
        {
            Counter[] myCounters = new Counter[3]
            myCounters[0] = new Counter("Counter 1");
            myCounters[1] = new Counter("Counter 2");
            myCounters[2] = myCounters[0];
            for (int i = 0; i < 4; i++)
            {
               // call Increment on myCounters[0] instance
               myCounters[0].Increment();
            }
            for (int i = 0; i < 9; i++)
            {
               // call Increment on myCounters[1] instance
               myCounters[1].Increment(); 
            }            
            // PrintCounters method call
            PrintCounters(myCounters);
            // call Reset on myCounters[2] instance
            myCounters[2].Reset();
            // PrintCounters method call 
            PrintCounters(myCounters);
        }
