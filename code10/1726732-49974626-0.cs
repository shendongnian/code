    class MyClass
    {
        private int[] _myArray;
    
        public int[] MyArray
        {
            get {return _myArray;}
            set
            {
                if (value == null) { _myArray = new int[2] { 0, 0 }; }
                else { _myArray = value; }
            }
        }
        public MyClass()
        {
            this.MyArray = new int[2] { 0, 0 };
        }
    }
