        public List<string> GetDependenciesFrom (Dictionary<string, List<string>> rules, string key)
        {
            // it contains itself 
            List<string> result = new List<string> { key };
            
            if (rules.ContainsKey(key))
            {
                foreach (var val in rules[key])
                {
                    if (!result.Contains(val))
                    {
                        result.Add(val);
                        foreach (string newval in GetDependenciesFrom(rules, val))
                        {
                            if (!result.Contains(newval))
                            {
                                result.Add(newval);
                            }
                        }
                    }
                }
            }
            return result;
        }
