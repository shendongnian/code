    foreach(Item i on ItemCollection)
    {
       Something s = new Something(i);
       s.EventX += (sender, eventArgs) => { ProcessItem(eventArgs.Item);};
       SomethingCollection.Add(s);
    }
