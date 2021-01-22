            string s = "ababababajjjaazsiajjsoajiojsioajlmmzaaokpdahgffaiojsia";
            var sw = new Stopwatch();
            sw.Start();
            var toRemove = new char[] { 'j', 'a', 'z' };
            for (int i = 0; i < 1000000; i++)
            {
                StringBuilder sb = new StringBuilder(s.Length, s.Length);
                foreach (var c in s) if (!toRemove.Contains(c)) sb.Append(c);
            }
            Console.WriteLine("StringBuilder " + sw.Elapsed);
            sw.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                new string(s.Where(c => !toRemove.Contains(c)).ToArray());
            }
            Console.WriteLine("new String " + sw.Elapsed);
