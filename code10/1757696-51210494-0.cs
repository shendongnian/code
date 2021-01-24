    int[] indexesCount = new int[tasSprites.Length];
    while (taslar.Count < 16)
    {
        int arrIndex = UnityEngine.Random.Range(0, tasSprites.Length);
        if (indexesCount[arrIndex] == 2)
        {
            continue;
        }
        indexesCount[arrIndex]++;
        tasSprite = tasSprites[arrIndex];
        tasName = tasSprite.name;
        taslar.Add(Int32.Parse(tasName));
    }
