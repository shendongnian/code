    class Program
    {
        public static void Main()
        {
            byte[] pattern = new byte[] {12,3,5,76,8,0,6,125};
            byte[] toBeSearched = new byte[] { 23, 36, 43, 76, 125, 56, 34, 234, 12, 3, 5, 76, 8, 0, 6, 125, 234, 56, 211, 122, 22, 4, 7, 89, 76, 64, 12, 3, 5, 76, 8, 0, 6, 125};
            List<int> positions = SearchBytePattern(pattern, toBeSearched);
            foreach (var item in positions)
            {
                Console.WriteLine("Pattern matched at pos {0}", item);
            }
        }
        static public List<int> SearchBytePattern(byte[] pattern, byte[] bytes)
        {
            List<int> positions = new List<int>();
            int patternLength = pattern.Length;
            int totalLength = bytes.Length;
            byte firstMatchByte = pattern[0];
            for (int i = 0; i < totalLength; i++)
            {
                if (firstMatchByte == bytes[i] && totalLength - i >= patternLength)
                {
                    byte[] match = new byte[patternLength];
                    Array.Copy(bytes, i, match, 0, patternLength);
                    if (match.SequenceEqual<byte>(pattern))
                    {
                        positions.Add(i);
                        i += patternLength - 1;
                    }
                }
            }
            return positions;
        }
    }
