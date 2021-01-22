    try
    {
        db.SubmitChanges(ConflictMode.ContinueOnConflict);
    }
    catch (ChangeConflictException e)
    {
        Console.WriteLine("Optimistic concurrency error.");
        Console.WriteLine(e.Message);
        Console.ReadLine();
        foreach (ObjectChangeConflict occ in db.ChangeConflicts)
        {
            MetaTable metatable = db.Mapping.GetTable(occ.Object.GetType());
            Customer entityInConflict = (Customer)occ.Object;
            Console.WriteLine("Table name: {0}", metatable.TableName);
            Console.Write("Customer ID: ");
            Console.WriteLine(entityInConflict.CustomerID);
            foreach (MemberChangeConflict mcc in occ.MemberConflicts)
            {
                object currVal = mcc.CurrentValue;
                object origVal = mcc.OriginalValue;
                object databaseVal = mcc.DatabaseValue;
                MemberInfo mi = mcc.Member;
                Console.WriteLine("Member: {0}", mi.Name);
                Console.WriteLine("current value: {0}", currVal);
                Console.WriteLine("original value: {0}", origVal);
                Console.WriteLine("database value: {0}", databaseVal);
            }
        }
    }
