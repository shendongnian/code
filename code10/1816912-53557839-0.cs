    ...
    else
    {
        for (var i = 0; i<carries; i++)
        {
            idx = idx + 1;
            var itemClone = new Item();
            itemClone.position = idx
            itemClone.is_scheduled = item.is_scheduled;
            //...set other itemClone property values
    
            Trace.WriteLine($"pos:{itemClone.position}");
    
            result.Add(itemClone);
    
        }
    }
    ...
