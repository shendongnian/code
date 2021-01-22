    public static class EnumerableEx
    {
        public static IEnumerable<string> SplitBy(this string str, int chunkLenght)
        {
            if (String.IsNullOrEmpty(str))
                throw new ArgumentException();
            if (chunkLenght < 1)
                throw new ArgumentException();
                
            int stringLength = str.Length;
            for (int i = 0; i < stringLength; i += chunkLenght)
            {
                if (i + chunkLenght > stringLength)
                {
                    chunkLenght = stringLength - i;
                }
    
                yield return str.Substring(i, chunkLenght);
            }
        }
    }
