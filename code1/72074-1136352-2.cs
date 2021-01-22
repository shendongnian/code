    int? max = null;
    int maxIndex = -1;
    for (int i = 0; i < intList.Count; i++)
    {
        if (!max.HasValue || (intList[i] > max))
        {
            max = intList[i];
            maxIndex = i;
        }
    }
