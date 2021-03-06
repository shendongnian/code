        private const string Cyrillic = "AaБбВвГг...";
        private const string Latin = "AaBbVvGg...";
        private Dictionary<char, string> mLookup;
        public string Romanize(string russian) {
            if (mLookup == null) {
                mLookup = new Dictionary<char, string>();
                for (int ix = 0; ix < Cyrillic.Length; ++ix) {
                    mLookup.Add(Cyrillic[ix], new string(Latin[ix], 1));
                }
            }
            var buf = new StringBuilder(russian.Length);
            foreach (char ch in russian) {
                if (mLookup.ContainsKey(ch)) buf.Append(mLookup[ch]);
                else buf.Append(ch);
            }
            return buf.ToString();
        }
