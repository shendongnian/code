    class Foo
    {
      public int Something;
      public static Foo Instance = new Foo();
      public void Reset()
      {
        Instance = new Foo();
      }
    }
    
    void test
    {
      int i = Foo.Instance.Something;
    }
