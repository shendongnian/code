    public static class DictionaryExtensions
    {
        public static TKey[] Shuffle<TKey, TValue>(
           this System.Collections.Generic.Dictionary<TKey, TValue> source)
        {
            Random r = new Random();
            TKey[] wviTKey = new TKey[source.Count];
            source.Keys.CopyTo(wviTKey, 0);
            for (int i = wviTKey.Length; i > 1; i--)
            {
                int k = r.Next(i);
                TKey temp = wviTKey[k];
                wviTKey[k] = wviTKey[i - 1];
                wviTKey[i - 1] = temp;
            }
            return wviTKey;
        }
    }
