    public void MyMethod()
    { // 1
        { // 2 -- invisible 
          for(int x=10; x<10; x++)   // x2
          { // 3
            int i=10;  // i3
            var objX = new MyOtherClass(); // objX3
          } //3 
        } // 2
        { // 4 -- invisible
          for(int x=10; x<10; x++)  // x4
          { // 5
            int i=10;  // i5
            var objX = new MyOtherClass();  // objX5
          } //5
       } // 4
    } // 1
