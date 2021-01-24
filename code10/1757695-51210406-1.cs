    while (taslar.Count < 16)
    {
        int arrIndex = UnityEngine.Random.Range(0, tasSprites.Length);
        tasSprite = tasSprites[arrIndex];
        tasName = tasSprite.name;
        int value = Int32.Parse(tasName);
        if (taslar.Count(t => t == value) < 2)
        {
            taslar.Add(value);
        }
    }
