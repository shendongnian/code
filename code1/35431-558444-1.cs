    if(idCollection.Count <4)
    {
        throw new ArgumentException("Source array not long enough");
    }
    List<long> FourUniqueIds = new List<long>(4);
    while(FourUniqueIds.Count <4)
    {
        long temp = idCollection[random.Next(idCollection.Count)];
        if(!idCollection.Contains(temp))
        {
            FourUniqueIds.add(temp);
        }
    }
