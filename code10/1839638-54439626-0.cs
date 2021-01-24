    foreach(var item in list)
    {
        if(item is Child1)
        {
            var child1 = (Child1)item;
            child1.DoSomething();
        }
        else if(...)
        {
            ...
        }
    }
