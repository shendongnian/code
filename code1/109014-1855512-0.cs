    const int MaxItemsToShuffle = 20;
    public static IEnumerable<int> RandomIndexes(int count)
    {
        Random random = new Random();
        int indexCount = Math.Min(count, MaxItemsToShuffle);
        int[] indexes = new int[indexCount];
        if (count > MaxItemsToShuffle)
        {
            int cur = 0, subsetCount = MaxItemsToShuffle;
            for (int i = 0; i < count; i += 1)
            {
                if (random.NextDouble() <= ((float)subsetCount / (float)(count - i + 1)))
                {
                    indexes[cur] = i;
                    cur += 1;
                    subsetCount -= 1;
                }
            }
        }
        else
        {
            for (int i = 0; i < count; i += 1)
            {
                indexes[i] = i;
            }
        }
        for (int i = indexCount; i > 0; i -= 1)
        {
            int curIndex = random.Next(0, i);
            yield return indexes[curIndex];
            indexes[curIndex] = indexes[i - 1];
        }
    }
