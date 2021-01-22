    MyDataContext context = new MyDataContext();
    MyObject obj;
    if (new Random().NextDouble() > .5)
    {
        obj = new MyObject();
        context.MyObjects.InsertAllOnSubmit(obj);
    }
    else
        obj = context.MyObjects.First();
