    var originalItems = 
        from item in (originalAccessor.Collection.Target as IEnumerable).Cast<Object>()
        select A_Accessor.B.AttachShadow(item);
    var copyItems = 
        from item in (copyAccessor.Collection.Target as IEnumerable).Cast<Object>()
        select A_Accessor.B.AttachShadow(item); 
    foreach(var original in originalItems) 
    { 
        String originalName = original.Name;
        A_Accessor.B copy = copyItems.First(b => b.Name == originalName);
        // ...
    }
