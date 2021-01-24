    public abstract
    class Array<T>
    {
      private T[]  data;
    
      protected Array(int size) { data = new T[size]; }
      public T this[int i]
      {
        get { return data[i]; }
        set { data[i] = value; }
      }
    };
    
    public Alias : Array<int>
    {
      static public int Length = 10;
      public Area() : base(Length) {}
    };
