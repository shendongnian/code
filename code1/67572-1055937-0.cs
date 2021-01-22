    public void FooBar( IEnumerable<int> bar )
    {
      ...
    }
    int[] array = new int[32];
    FooBar( array.Skip(4) );
