    foreach (var foo in foos)
    {
        using (var context = new MyDataContext())
        {
            context.Foos.InsertOnSubmit(foo);
            try
            {
                context.SubmitChanges();
            }
            catch {}
        }
    }
