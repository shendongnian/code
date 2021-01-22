            Stopwatch s = new Stopwatch();
            var p = new { FirstName = "Bill", LastName = "Gates" };
            int n = 1000000;
            long fElapsedMilliseconds = 0, fElapsedTicks = 0, cElapsedMilliseconds = 0, cElapsedTicks = 0;
            string result;
            s.Start();
            for (var i = 0; i < n; i++)
                result = (p.FirstName + " " + p.LastName);
            s.Stop();
            cElapsedMilliseconds = s.ElapsedMilliseconds;
            cElapsedTicks = s.ElapsedTicks;
            s.Reset();
            s.Start();
            for (var i = 0; i < n; i++)
                result = string.Format("{0} {1}", p.FirstName, p.LastName);
            s.Stop();
            fElapsedMilliseconds = s.ElapsedMilliseconds;
            fElapsedTicks = s.ElapsedTicks;
            s.Reset();
            Console.Clear();
            Console.WriteLine("Console.WriteLine(\"{0} {1}\", p.FirstName, p.LastName); took (avg): " + (fElapsedMilliseconds) + "ms - " + (fElapsedTicks) + " ticks");
            Console.WriteLine("Console.WriteLine(p.FirstName + \" \" + p.LastName); took (avg): " + (cElapsedMilliseconds) + "ms - " + (cElapsedTicks) + " ticks");
            Thread.Sleep(4000);</pre>
