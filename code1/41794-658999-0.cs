    HashSet<string> keysToReturn = new HashSet<string>();
    int numberPossibleToGet = (cachedKeys.Length <= requestedNumberToGet) ? cachedKeys.Length : requestedNumberToGet;
    Random rand = new Random();
    
    DateTime breakoutTime = DateTime.Now.AddMilliseconds(5);
    int length = cachedKeys.Length;
    
    while (DateTime.Now < breakoutTime && keysToReturn.Count < numberPossibleToGet) {
        int i = rand.Next(0, length);
        while (!keysToReturn.Add(cachedKeys[i])) {
            i++;
            if (i == length)
                i = 0;
        }
    }
    
