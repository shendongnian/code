        string[] testCollection = {"1", "2", "3", "4", "5"};
        
        forEachDelegate primaryFunction = delegate(object o)
        {
            Response.Write(o.ToString());
        };
        forEachDelegate first = delegate(object o)
        {
            Response.Write("first");
        };
        forEachDelegate odd = delegate(object o)
        {
            Response.Write("odd");
        };
        forEachDelegate after = delegate(object o)
        {
            Response.Write("after");
        };
        Randoms.forEach(testCollection, primaryFunction, null, first, null, odd, null, after, Randoms.forEachExeuction.Concurrent);
