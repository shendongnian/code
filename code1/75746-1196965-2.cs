    public void MyMethod()
    { // 1
        int i=10; // i1
        { // 2 -- invisible brace
          for(int x=10; x<10; x++) // x2
          { // 3
            int i=10;  // i3
            var objX = new MyOtherClass(); // objX3
          } // 3
        } // 2
        var objX = new OtherClasOfMine(); // objX1
    } // 1
