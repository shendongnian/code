               string input = "time, M1.A, M1.B, M1.C, M2.A, M2.B, M2.C, M3.A, M3.B, M3.C";
                string pattern1 = @"^(?'name'[^,]*),(?'machines'.*)";
                Match match1 = Regex.Match(input, pattern1);
                string name = match1.Groups["name"].Value;
                string machines = match1.Groups["machines"].Value.Trim();
                string pattern2 = @"\s*(?'machine'[^.]*).(?'attribute'\w+)(,|$)";
                MatchCollection matches = Regex.Matches(machines, pattern2);
                Dictionary<string, List<string>> dict = matches.Cast<Match>()
                    .GroupBy(x => x.Groups["machine"].Value, y => y.Groups["attribute"].Value)
                    .ToDictionary(x => x.Key, y => y.ToList());
