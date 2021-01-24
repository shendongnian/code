    foreach (var outer in gamesplayers)
    {
     foreach (var inner in outer.Value)
     {
        if(inner.Key == "Something")
        {
            // do something
            inner.Value = “test”;
        }
     }
    }
