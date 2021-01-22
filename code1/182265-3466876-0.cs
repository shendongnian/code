            string[] sArr = { "File", "Block", "Detected:", "2010-08-11", "11:48:50", "29.01.1987 12:23" };
            foreach (var s in sArr)
            {
                DateTime d;
                if (DateTime.TryParse(s, out d))
                {
                    Console.WriteLine(d);
                }
            }
