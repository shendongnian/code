    var somethings = ItemCollection.Select(
            i =>
            {
                Something s = new Something();
                s.EventX += delegate { ProcessItem(i); };
                return s;
            });
    foreach(Something s in somethings)
        SomethingCollection.Add(s);
