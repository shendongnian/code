            string input = "abcdefghijklmnopqrstuvwxyz";
            const int INTERVAL = 5;
            
            List<string> lst = new List<string>();
            int i = 0;
            while (i < input.Length)
            {
                string sub = input.Substring(i, i + INTERVAL < input.Length ? INTERVAL : input.Length - i);
                Console.WriteLine(sub);
                lst.Add(sub);
                i += INTERVAL;
            }
