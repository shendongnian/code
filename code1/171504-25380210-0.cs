    public class LeetSpeakDecoder
    {
        private Dictionary<string, IEnumerable<string>> Cache { get; set; }
        private Dictionary<string, string> Rules { get; set; }
        public LeetSpeakDecoder()
        {
            Cache = new Dictionary<string, IEnumerable<string>>();
            Rules = new Dictionary<string,string>();
            Rules.Add("4", "A");
            // add rules here...
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
                list.Add(Rules[leet]);
            }
        }
    }
