        private static void spin(ref Stopwatch sw, double spinSeconds)
        {
            sw.Start();
            while (sw.ElapsedTicks < spinSeconds) { }
            sw.Stop();
        }
