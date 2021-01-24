    public void edit(string Quantity) 
    {
        var db = new SQLiteConnection(Class1.dpPath);
        var logintable = new LoginTable();
        logintable.quantity = Quantity;
        db.Update(logintable);
    }
