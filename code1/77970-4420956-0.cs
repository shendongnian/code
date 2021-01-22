        static void Main()
        {
            List<int> castTimings = new List<int>();
            List<int> allocTimings = new List<int>();
            for (int i = 0; i < TEST_RUNS; ++i)
            {
                castTimings.Add(RunCastMethod().Milliseconds);
                allocTimings.Add(RunAllocationMethod().Milliseconds);
            }
            MessageBox.Show(string.Format("Casting Method took: {0}ms", castTimings.Average() ));
            MessageBox.Show(string.Format("Allocation Method took: {0}ms", allocTimings.Average() ));
        }
        private static TimeSpan RunAllocationMethod() {
            DateTime start = DateTime.Now;
            for (int i = 0; i < TEST_ITERATIONS; ++i)
            {
                IntPtr ptr = new IntPtr(i);
            }
            return ( DateTime.Now - start );
        }
        private static TimeSpan RunCastMethod()
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i < TEST_ITERATIONS; ++i)
            {
                IntPtr ptr = (IntPtr) i;
            }
            return (DateTime.Now - start);
        }
