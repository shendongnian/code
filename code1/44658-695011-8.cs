    public class Data
    {
        private static MyDBEntities _myDBEntities;
        public static MyDBEntities MyDBEntities
        {
            get
            {
                if (_myDBEntities == null)
                {
                    _myDBEntities = new MyDBEntities ();
                }
                return _myDBEntities;
            }
            set { _myDBEntities = value; }
        }
    }
