    while(i < 1000)
    {
        MyEntity Wibble = new MyEntity();
        Wibble.Name = "Test " + i.ToString();
        Context.AddToTests(Wibble);
        try
        {
            Context.SaveChanges();
        }
        catch
        {
            Context.ObjectStateManager.GetObjectStateEntry(Wibble).Delete();
        }
    }
