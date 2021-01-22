    class Person {
      int age = 0;
    
      public int Age {
        get { return age; }
        set { 
          //do validation
          if (valid) {
            age = value;
          }
          //Error conditions if you want them.
        }
      } 
      //More getters/setters
    }
