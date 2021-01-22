        // Previous LINQ version with BUG identified in comments below
        //static IEnumerable<string> Split(string str, int chunkSize)
        //{
        //    return Enumerable.Range(0, str.Length / chunkSize)
        //        .Select(i => str.Substring(i * chunkSize, chunkSize));
        //}
        // Revised to check arguments and make use of a for/yield to reduce
        // recalculation and improve clarity for non-LINQ "heads" :)
        public static IEnumerable<string> Split(string str, int chunkSize)
        {
            if (string.IsNullOrEmpty(str))
            {
                yield break;
            }
            if (chunkSize < 1)
            {
                throw new ArgumentException("chunkSize must be greater than 0", "chunkSize");
            }
            int totalChunks = str.Length/chunkSize;
            for (int i = 0; i <= totalChunks; i++)
            {
                int startIndex = i*chunkSize;
                int length = Math.Min(chunkSize, str.Length - startIndex);
                // The Math.Min equivalent is
                // int length = startIndex + chunkSize < text.Length ? chunkSize : text.Length - startIndex;
                
                yield return str.Substring(startIndex, length);
            }
        }
