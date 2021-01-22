    List<string> GetSomeKeysSwapping(string[] cachedKeys, int requestedNumberToGet)
    {
        int numberPossibleToGet = Math.Min(cachedKeys.Length, requestedNumberToGet);
        List<string> keys = new List<string>(cachedKeys);
        List<string> keysToReturn = new List<string>(numberPossibleToGet);
        Random rand = new Random();
        for (int i = 0; i < numberPossibleToGet; i++)
        {
            int index = rand.Next(numberPossibleToGet - i) + i;
            keysToReturn.Add(keys[index]);
            keys[index] = keys[i];
        }
        return keysToReturn;
    }
    List<string> GetSomeKeysEnumerable(string[] cachedKeys, int requestedNumberToGet)
    {
        Random rand = new Random();
        return TakeRandom(cachedKeys, requestedNumberToGet, rand).ToList();
    }
