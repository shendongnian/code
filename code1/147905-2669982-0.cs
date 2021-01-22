    using (TransactionScope scope = new TransactionScope())
    {
        if (!Context.MyTables.Any(t => t.Value == in.Value))
        {
            MyLinqModels.MyTable t = new MyLinqModels.MyTable()
            {
               Name = in.Name,
               Value = in.Value
            };
    
            // Do some stuff in the transaction
    
            scope.Complete();
        }
    }
