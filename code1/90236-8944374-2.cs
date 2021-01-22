    public static class EnumerableEx
    {    
        public static IEnumerable<string> SplitBy(this string str, int chunkLength)
        {
            if (String.IsNullOrEmpty(str))
                throw new ArgumentException();
            if (chunkLength < 1)
                throw new ArgumentException();
            int stringLength = str.Length;
            for (int i = 0; i < stringLength; i += chunkLength)
            {
                if (i + chunkLength > stringLength)
                {
                    chunkLength = stringLength - i;
                }
                yield return str.Substring(i, chunkLength);
            }
        }
    }
