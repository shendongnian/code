    (using context = new Dbcontext())
    {
    Table1 object1 = new Table1
    {
        Attribute1 = 1, //(autoincrement really)
        Attribute2 = "random value",
        Attribute3 = "random value",
    };
    
    foreach (Table2 obj2 in NewValues)
    {
        Table2 o = new Table2() {Attribute1 = obj2.int, Attribute2 = obj2.string};
        context.Table2.Attach(o);
        object1.Attribute4.Add(o);
    }
    }
