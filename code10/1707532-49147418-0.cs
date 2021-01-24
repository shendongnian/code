            string[] lines = File.ReadAllLines(@"C:\input.txt");
            string[] proxylines = File.ReadAllLines(@"C:\proxies.txt");
            for (int i = 0; i < Math.Min(lines.Length, proxylines.Length); i++)
            {
                string line = lines[i];
                string proxy = proxylines[i];
                // actions ...
            }
