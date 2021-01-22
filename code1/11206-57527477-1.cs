    using System;
    static class MainClass {
        private static int IndexOfNth(this string target, string substring,
                                           int seqNr, int startIdx = 0)
        {
            if (seqNr < 1)
            {
                throw new IndexOutOfRangeException("Parameter 'nth' must be greater than 0.");
            }
            var idx = target.IndexOf(substring, startIdx);
            if (idx < 0 || seqNr == 1) { return idx; }
            return target.IndexOfNth(substring, --seqNr, ++idx); // skip
        }
        static void Main () {
            Console.WriteLine ("abcbcbcd".IndexOfNth("bc", 1));
            Console.WriteLine ("abcbcbcd".IndexOfNth("bc", 2));
            Console.WriteLine ("abcbcbcd".IndexOfNth("bc", 3));
            Console.WriteLine ("abcbcbcd".IndexOfNth("bc", 4));
        }
    }
