            bool line1 = false;
            var value1 = 0;
            var sumtag = 0;
            Match m;
            Regex myRegex = new Regex(@"AD=\""([\d]+)\""");
            foreach (string line in File.ReadLines(@"c:\test.txt", Encoding.UTF8))
            {
                if (line.Length < 2 || !line.Contains("AD=")) continue; // test i f line has more than 2 char or doesnt contains "AD=", you could comment
                if (!line1)
                {
                    line1 = true;
                    m = myRegex.Match(line);
                    value1 = Convert.ToInt32(m.Groups[1].ToString());
                    continue;
                }
                m = myRegex.Match(line);
                sumtag = Convert.ToInt32(m.Groups[1].ToString()) + value1;
                // sumtag contains the sum of 2 consecutives tag
                // you could process with it
                line1 = false;
            }
