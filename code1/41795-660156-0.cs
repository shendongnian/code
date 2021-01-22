    List<string> GetSomeKeys(string[] cachedKeys, int requestedNumberToGet)
    {
        int numberPossibleToGet = Math.Min(cachedKeys.Length, requestedNumberToGet);
        List<string> keysRemaining = new List<string>(cachedKeys);
        List<string> keysToReturn = new List<string>(numberPossibleToGet);
        Random rand = new Random();
        for (int i = 0; i < numberPossibleToGet; i++)
        {
            int randomIndex = rand.Next(keysRemaining.Count);
            keysToReturn.Add(keysRemaining[randomIndex]);
            keysRemaining.RemoveAt(randomIndex);
        }
        return keysToReturn;
    }
