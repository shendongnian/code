    (using context = new Dbcontext())
    {
      using (var transaction = context.Database.BeginTransaction(IsolationLevel.Serializable))
      {
        Table1 object1 = new Table1
        {
          Attribute1 = 1, //(autoincrement really)
          Attribute2 = "random value",
          Attribute3 = "random value",
        };
        List<Table2> tempTable2 = new List<Object2>();
        foreach (Table2 obj2 in NewValues)
        {
          Table2 o = new Table2() {Attribute1 = obj2.int, Attribute2 = obj2.string};
          tempTable2.Add(o);
        }
        context.Table1.Add(object1);
        context.SavesChanges();
    
        Table1 object11 = context.Table1.First(o => o.Attribute1 == object1.Attribute1);
        object11.Attribute4 = tempTable2
        context.SavesChanges();
      }
    }
