    public static void InsertingItem(){
        using (myDbContext db = new myDbContext()){
            Item example = new Item(){
                // refactor the AlreadyExistingGroup method to accept a DbContext, or to move
                // the code from the method here
                GROUPS = AlreadyExistingGroup(dbContext) ;
            }
            db.ITEMS.Add(example);
            db.SaveChanges();
        }
    }
