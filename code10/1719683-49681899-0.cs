                List<string> test = new List<string>();
                string pattern = "Current Program(s):";
                string[] allLines = File.ReadAllLines(@"C:\Users\xyz\Source\demo.txt");
                foreach (var line in allLines)
                {
                    if (line.Contains(pattern))
                    {
                        test.Add(line.Substring(line.IndexOf(pattern) + pattern.Length));
                    }
                }
