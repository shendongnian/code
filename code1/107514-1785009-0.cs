    class Name
    {
      public string FirstName;
      public string LastName;
    
      public string GetFullName()
      {
         return this.FirstName + this.LastName; 
      }
    
    }
    
    //code demonstrating usage of class:
    Name someName = new Name();
    someName.FirstName = "Aaron";
    someName.LastName = "Smith";
    
    //no parameter is needed for the GetFullName method because
    //it will access the member variables
    Console.WriteLine( someName.GetFullName() );
