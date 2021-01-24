    class MyClass
    {
        private int[] _myArray;
        public int[] MyArray
        {
            get { return _myArray; }
            set
            {
                if (value == null) { _myArray = new int[2] { 0, 0 }; return; }
                else { _myArray = value; return; }
            }
        }
    }
