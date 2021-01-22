        protected static int[] testIntArray;
        protected static void Bar(out int[] x)
        {
            x = new int[100];
            for (int i = 0; i != 100; ++i)
            {
                Thread.Sleep(5);
                x[i] = 1; // NullReferenceException
            }
        }
        protected static void Work()
        {
            Bar(out testIntArray);
        }
        static void Main(string[] args)
        {
            var t1 = new Thread(Work);
            t1.Start();
            while (t1.ThreadState == ThreadState.Running)
            {
                testIntArray = null;
            }
        }
    }
