    public static IEnumerable<string> Split(this string str, int chunkSize)
        {
            var splits = new List<string>();
            if (str.Length < chunkSize) { chunkSize = str.Length; }
            splits.AddRange(Enumerable.Range(0, str.Length / chunkSize).Select(i => str.Substring(i * chunkSize, chunkSize)));
            splits.Add(str.Length % chunkSize > 0 ? str.Substring((str.Length / chunkSize) * chunkSize, str.Length - ((str.Length / chunkSize) * chunkSize)) : string.Empty);
            return (IEnumerable<string>)splits;
        }
