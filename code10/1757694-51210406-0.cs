    while (taslar.Count < 16)
    {
        int arrIndex = UnityEngine.Random.Range(0, tasSprites.Length);
        tasSprite = tasSprites[arrIndex];
        tasName = tasSprite.name;
        if (taslar.Count(t => t == tasName) < 2)
        {
            taslar.Add(Int32.Parse(tasName));
        }
    }
