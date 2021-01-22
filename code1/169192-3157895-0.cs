            var watch = Stopwatch.StartNew();
            char[] chars = new char[128 * 1024];
            Random rand = new Random(); // fill with junk
            for (int i = 0; i < chars.Length; i++) chars[i] =
                 (char) ((int) 'a' + rand.Next(26));
            
            int sum = 0;
            string s = new string(chars);
            int len = s.Length;
            for(int i = 0 ; i < len ; i++)
            {
                sum += (int) chars[i];
            }
            watch.Stop();
            Console.WriteLine(sum);
            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadLine();
