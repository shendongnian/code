    IList<object> objs = new List<object>
    {
        new Object(),
        new Object(),
        new Object(),
        new Object()
    };
    
    // to access first element: objs[0]
    // to access last element: objs[objs.Count - 1]
    System.Diagnostics.Debug.WriteLine("First object - do something special");
    
    foreach (object o in objs.Skip(1))
    {
        System.Diagnostics.Debug.WriteLine("object Do something else");
    }
