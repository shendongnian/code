    public static void RunChangeList()
    {
        var objs = Enumerable.Range(0, 10).Select(_ => new MyObject() { SimpleInt = 0 });
        var whatInt = ChangeToList(objs);   // whatInt gets 0
    }
    public static int ChangeToList(IEnumerable<MyObject> objects)
    {
        var objectList = objects.ToList();
        objectList.First().SimpleInt = 5;
        return objects.First().SimpleInt;
    }
