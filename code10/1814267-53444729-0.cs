        private static TimeSpan _pastTimeSpan;
        static void Main(string[] args)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            _pastTimeSpan = _stopwatch.Elapsed;
            ... code ...
            MyElapsedTime(_stopwatch.Elapsed);
            ... code ...
            MyElapsedTime(_stopwatch.Elapsed);
            ... code ...
            MyElapsedTime(_stopwatch.Elapsed);
            _stopwatch.Stop();
            Console.WriteLine("Time elapsed total: {0:hh\\:mm\\:ss}", _stopwatch.Elapsed);
         }
        private static void MyElapsedTime(TimeSpan ts)
        {
            // Get the last TimeSpan
            TimeSpan pastTimeSpan = _pastTimeSpan;
            // Update last TimeSpan with current
            _pastTimeSpan = ts;
            // Get difference between two
            TimeSpan diffTs = ts.Subtract(pastTimeSpan);
            Console.WriteLine(string.Format("Elapsed time {0}:{1} | Segment took {2}:{3}", Math.Floor(ts.TotalMinutes), ts.ToString("ss\\.ff"), Math.Floor(diffTs.TotalMinutes), diffTs.ToString("ss\\.ff")));
        }
