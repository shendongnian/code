    class TestClass
    {
      private Album album;
    
      public void TestAssignment(string name)
      {
        // Here I'm using this style of property assignment to make it very explicit why it's not thread-safe
        this.album = new Album();
        this.album.Name = name;
        ...
      }
    }
