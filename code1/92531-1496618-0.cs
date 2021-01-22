        public class firstXCharsComparer : IEqualityComparer<string>
        {
            private int numChars;
            public firstXCharsComparer(int numChars)
            {
                this.numChars = numChars;
            }
            public bool Equals(string x, string y)
            {
                return x.Substring(0, numChars) == y.Substring(0, numChars);
            }
            public int GetHashCode(string obj)
            {
                return obj.Substring(0, numChars).GetHashCode();
            }
        }
        static void Main(string[] args)
        {
            string[] arr = { "abcdefXXX872358", "abcdef200X8XXX58", "abcdef200X872359", "6T1XXXXXXXXXXXX11", "7AbcdeHA30XXX541", "7AbcdeHA30XXX691" };
            var result = arr.ToList().Distinct(new firstXCharsComparer(6));
            result.Count();
        }
