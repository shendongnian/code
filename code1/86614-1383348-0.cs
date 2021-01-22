    public static class MyClass
    {
      static MyClass() {}
      private static MyClass LoadFromDatabase(int id)
      {
        // Get the data here....
      }
      public static MyClass LoadByKey(int id)
      {
        MyClass c = new MyClass();
        return c.LoadFromDatabase(id);
      }
    }
