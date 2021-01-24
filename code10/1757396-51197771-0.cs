            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach(var s in ngrms)
            {
                if (dict.ContainsKey(s))
                    dict[s]++;
                else
                    dict.Add(s, 1);
            }
            return dict.Where(a => a.Value > minCount);
