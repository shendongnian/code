    public static void InsertingItem(){
        Item example = new Item(){
            // DbContext #1 is created in this method
            GROUPS = AlreadyExistingGroup(); 
        }
        // And this is DbContext #2
        using (myDbContext db = new myDbContext()){
            db.ITEMS.Add(example);
            db.SaveChanges();
        }
    }
