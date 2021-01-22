    public class SomeClass
    {
      void Add(int index, int item) 
      { 
        // ...
      }
    }
    
    var anObject = new SomeClass()
        {
            {0, 4}, // Calls Add(0, 4)
            {4, 8}  // Calls Add(4, 8)
        }
