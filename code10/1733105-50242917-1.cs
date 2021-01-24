    public void Edit(int id, string quantity)
    {
       var db = new SQLiteConnection(Class1.dbPath);
       var table = db.Table<Class1.LoginTable>();
       var itemToEdit = table.First(f=>f.Id == id);
       itemToEdit.quantity = quantity;
       db.Update(itemToEdit);
    }
