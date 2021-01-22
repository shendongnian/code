    class MyObject {
    
       private static int nextId = 0;
    
       public MyObject(string name) {
          Id = ++nextId;
          Name = name;
       }
    
       public int Id { get; private set; }
       public string Name { get; private set; }
    }
