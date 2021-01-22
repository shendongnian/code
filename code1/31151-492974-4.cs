        Dictionary<int, int> counts = new Dictionary<int, int>();
        foreach (int value in data)
        {
            int count;
            counts.TryGetValue(value, out count);
            counts[value] = count + 1;
        }
        int maxCount = -1, maxValue = 0;
        foreach (KeyValuePair<int, int> pair in counts)
        {
            if (pair.Value > maxCount)
            {
                maxCount = pair.Value;
                maxValue = pair.Key;
            }
        }
        Console.WriteLine(maxCount + ": " + maxValue);
