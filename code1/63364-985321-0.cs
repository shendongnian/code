    class MyClass
    {
       private object someData;
    
       public MyClass(object data)
       {
          this.someData = data;
       }
    
       public MyClass() : this(new object())
       {
          // Calls the previous constructor with a new object, 
          // setting someData to that object
       }
    }
