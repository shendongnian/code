      MyObject obj;
      using (var stream = new FileStream(path, FileMode.Open))
      {
        obj = new MyObject(stream);
      }
      using (obj)
      {
    
      }
