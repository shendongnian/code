    using (MyDataContext context = new MyDataContext()) // DB connection established.
    {
        MyTableRecord myEntity = myDataContext.Table.FindEntity(12345); // retrieve entity
        foreach (var record in MyEntity.RelatedTable)
        {
            ...
        }
    }
