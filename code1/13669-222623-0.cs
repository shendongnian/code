    List<ICloneable> oldList = new List<ICloneable>();
    List<ICloneable> newList = new List<ICloneable>(oldList.Count);
    
    oldList.ForEach((item) =>
        {
            newList.Add((ICloneable)item.Clone());
        });
