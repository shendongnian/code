            string reg = "\"\\[([^.]+)\\.([^.]+)\\.([^.]+)\\.([^.]+)\\]\"(\\s+-\\s+\"(([0-9]+):([0-9]+),?)+\")?";
            string reg2 = "([0-9]+):([0-9]+),?";
            Regex r = new Regex(reg);
            Console.WriteLine(a);
            Console.WriteLine(reg);
            Match m = r.Match(a);
            if (m.Success)
            {
                string category = m.Groups[1];
                string type = m.Groups[2];
                string group = m.Groups[3];
                string subgroup = m.Groups[4];
                MatchCollection mc = Regex.Matches(m.Groups[5].Value, reg2);
                List<string> numbers = new List<string>();
                foreach (Match match in mc)
                {
                    numbers.Add(match.Groups[1].Value);
                    numbers.Add(match.Groups[2].Value);
                }
            }
