    public class MyClass : IDisposable
    {
        private Database db;
        private int? _id;
        public MyClass()
        {
            db = new Database();
        }
        public int Id
        {
            get
            {
                if (_id == null) _id = db.GetIdFor(typeof(MyClass));
                return _id.Value;
            }
        }
        
        public void Dispose()
        {
            db.Close();
        }
    }
