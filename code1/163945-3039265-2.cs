    var curr = ListPrice.Current;
    if(ListPrice.MoveNext())
    {
        var lpc = ListPrice.Current;
        if(lpc.MoveToFirstChild())
        {
           var node = lpc.Name + "/" + lpc.Value;
                    
           while(lpc.MoveToNext())
           {
               node = lpc.Name + "/" + lpc.Value;
           }
        }
    }
