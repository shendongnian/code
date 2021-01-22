    (source, flags, initializers) =>
    {
        if(source == null)
            return null;
        if(initializers.ContainsKey(typeof(List<int>))
            target = (List<int>)initializers[typeof(List<int>)].Invoke((object)source);
        else
            target = new List<int>();
        
        if((flags & CloningFlags.Properties) == CloningFlags.Properties)
        {
            target.Capacity = target.Capacity.GetClone(flags, initializers);
        }
        
        if((flags & CloningFlags.CollectionItems) == CloningFlags.CollectionItems)
        {
            var targetCollection = (ICollection<int>)target;
            foreach(var item in (ICollection<int>)source)
            {
                targetCollection.Add(item.Clone(flags, initializers));
            }
        }
        
        return target;
    }
