    class SomeClass : IComparable
    { 
        private int myVal; 
        public int MyVal
        { 
            get { return myVal; } 
            set { myVal = value; }
        }
        public int CompareTo(object other) { /* implementation here */ }
    }
    class SortedCollection<T>
    {
        private T[] data;
        public T Top { get { return data[0]; } }
        
        /* rest of implementation here */
    }
    //..
    // calling code
    SortedCollection<SomeClass> col;
    col.Top.MyVal = 500;  // you can't really prevent this
