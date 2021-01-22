    static int GetRandom(List<int> usedNums)
    {
        List<int> missingNums = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            if (!usedNums.Contains(i))
                missingNums.Add(i);
        }
        Random r = new Random();
        int rMissingNumIndex = r.Next(0, missingNums.Count - 1);
        return missingNums[rMissingNumIndex];
    }
