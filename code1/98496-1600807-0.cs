    ItemCollection.ForEach(
        i =>
        {
            Something s = new Something();
            s.EventX += delegate { ProcessItem(i); };
            SomethingCollection.Add(s);
        });
