    public static class MyStaticClass
    {
        private static NonStaticObject _myObject = new NonStaticObject();
        
        //property
        public static NonStaticObject MyObject
        {
            get { return _myObject; }
            set { _myObject = value; }
        }
    }
