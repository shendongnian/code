    public static class Repository {
      private static DataBase _db; 
      // static constructor
      static Repository () {
        _db = new Database();
      }
      public static int GetCount() {
        return _db.Menus.Count();
      }
      public Item GetItem(int id) {
        return _db.Menus.FirstOrDefault(x=>x.Id == id);
      }
    }
