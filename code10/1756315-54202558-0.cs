    public static class DbFunctions
    {
       public static decimal MyFunctionABC(int param1, int param2)
       {
           using (var db = new MyDbContext())
           {
            return db.table.Take(1).Select(t => MyDbContext.MyFunctionABC(x, y)).Single();
           }
        }
     }
