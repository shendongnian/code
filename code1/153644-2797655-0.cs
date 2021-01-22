    public class Repository : IRepository
    {
        private readonly DataBase _db;
        public Repository(DataBase db)
        {
            _db = db;
        }
        public int GetCount()
        {
            return _db.Menus.Count();
        }
        public Item GetItem(int id)
        {
            return _db.Menus.FirstOrDefault(x=>x.Id == id);
        } 
    }
