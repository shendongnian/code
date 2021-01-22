    using (DataClasses1DataContext ctx = new DataClasses1DataContext())
    {
        var obj = ctx.DecimalColumnTables.First();
        Debug.Assert(obj.B != 0);
        obj.B = 0;
        ctx.SubmitChanges();
    }
