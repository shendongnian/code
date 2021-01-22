      public class LeetSpeakDecoder
        {
            private Dictionary<string, IEnumerable<string>> Cache { get; set; }
            private Dictionary<string, List<string>> Rules  = new Dictionary<string, List<string>>();
    
            public void AddRule(string key, string value)
            {
                List<string> keyRules = null;
                if (Rules.ContainsKey(key))
                {
                    keyRules = Rules[key];
                }
                else
                {
                    keyRules = new List<string>();
                    Rules[key] = keyRules;
                }
                keyRules.Add(value);
            }
    
            public LeetSpeakDecoder()
            {
                Cache = new Dictionary<string, IEnumerable<string>>();
                
    
                AddRule("4", "A");
                AddRule("4", "a");
               AddRule(@"/\", "A");
               AddRule("@", "A");
               AddRule("^", "A");
               AddRule("13", "B");
               AddRule("/3", "B");
               AddRule("|3", "B");
               AddRule("8", "B");
               AddRule("><", "X");
               AddRule("<", "C");
               AddRule("(", "C");
               AddRule("|)", "D");
               AddRule("|>", "D");
               AddRule("3", "E");
               AddRule("6", "G");
               AddRule("/-/", "H");
               AddRule("[-]", "H");
               AddRule("]-[", "H");
               AddRule("!", "I");
               AddRule("|_", "L");
               AddRule("_/", "J");
               AddRule("_|", "J");
               AddRule("1", "L");
               AddRule("0", "O");
               AddRule("0", "o");
               AddRule("5", "S");
               AddRule("7", "T");
               AddRule(@"\/\/", "W");
               AddRule(@"\/", "V");
               AddRule("2", "Z");
    
                const string nonAlpha = @"0123456789!@#$%^&*()-_=+[]{}\|;:'<,>./?""";
                foreach (var currentChar in nonAlpha)
                {
                    AddRule(currentChar.ToString(), "");
                }
            }
    
            public IEnumerable<string> Decode(string leet)
            {
                var list = new List<string>();
                if (Cache.ContainsKey(leet))
                {
                    return Cache[leet];
                }
    
                DecodeOneCharacter(leet, list);
                DecodeMoreThanOneCharacter(leet, list);
                DecodeWholeWord(leet, list);
    
                list = list.Distinct().ToList();
    
                Cache.Add(leet, list);
                return list;
            }
    
            private void DecodeOneCharacter(string leet, List<string> list)
            {
                if (leet.Length == 1)
                {
                    list.Add(leet);
                }
            }
    
            private void DecodeMoreThanOneCharacter(string leet, List<string> list)
            {
                if (leet.Length > 1)
                {   // we split the word in two parts and check how many variations each part will decode to
                    for (var splitPoint = 1; splitPoint < leet.Length; splitPoint++)
                    {
                        foreach (var leftPartDecoded in Decode(leet.Substring(0, splitPoint)))
                        {
                            foreach (var rightPartDecoded in Decode(leet.Substring(splitPoint)))
                            {
                                list.Add(leftPartDecoded + rightPartDecoded);
                            }
                        }
                    }
                }
            }
    
            private void DecodeWholeWord(string leet, List<string> list)
            {
                if (Rules.ContainsKey(leet))
                {
                    foreach (var ruleValue in Rules[leet])
                    {
                        list.Add(ruleValue);
                    }
                    
                }
            }
        }
