    struct MyStruct
    {
      public int SomeProp { get; set; }
    
      public MyStruct(int someVal) : this()
      {
         this.SomeProp = someVal;
      }
    }
