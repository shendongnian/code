    public static class CollectionExtension
    {
        public static IList<TSource> RandomizeCollection<TSource>(this IList<TSource> source, int maxItems)
        {
            int randomCount = source.Count > maxItems ? maxItems : source.Count;
            int?[] randomizedIndices = new int?[randomCount];
            Random random = new Random();
            for (int i = 0; i < randomizedIndices.Length; i++)
            {
                int randomResult = -1;
                while (randomizedIndices.Contains((randomResult = random.Next(0, source.Count))))
                {
                    //0 -> since all list starts from index 0; source.Count -> maximum number of items that can be randomize
                    //continue looping while the generated random number is already in the list of randomizedIndices
                }
                randomizedIndices[i] = randomResult;
            }
            IList<TSource> result = new List<TSource>();
            foreach (int index in randomizedIndices)
                result.Add(source.ElementAt(index));
            return result;
        }
    }
