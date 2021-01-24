    List<MyObject> nameNotNull = new List<MyObject>();
    List<MyObject> nameNull = new List<MyObject>();
    foreach (MyObject o in objectList)
    {
        if (!string.IsNullOrEmpty(o.Name))
        {
            nameNotNull.Add(o);
        }
        else
        {
            nameNull.Add(o);
        }
    }
