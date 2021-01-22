    struct MyStruct 
    {
        public MyStruct(int size) : this() 
        {
            this.Size = size; // <-- now works
        }
         public int Size { get; set; }
    }
