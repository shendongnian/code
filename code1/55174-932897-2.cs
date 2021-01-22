    public static class Helper
    {
        public static long Time(
            this Func<double, double> f,
            double testValue)
        {
            int imax = 120000;
            double avg = 0.0;
            Stopwatch st = new Stopwatch();
            for (int i = 0; i < imax; i++)
            {
                // note the timing is strictly on the function
                st.Start();
                var t = f(testValue);
                st.Stop();
                avg = (avg * i + t) / (i + 1);
            }
            Console.WriteLine("Average Val: {0}",avg);
            return st.ElapsedTicks/imax;
        }
    }
