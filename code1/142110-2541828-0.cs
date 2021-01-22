    Class Person
    {
       public string GetPersonName(Person person)
       {
         return person.FirstName + person.LastName;
       }
    
       //Calling the method without the use of delegate
       public void PrintName()
       {
          Console.WriteLine(GetPersonName(this));
       }
    
       //using delegate
       //Declare delegate which matches the methods signature
       public delegate string personNameDelegate(Person person);
    
      public void PrintNameUsingDelegate()
      {
          //instantiate
          personNameDelegate = new personNameDelegate(GetPersonName);
          
          //invoke
          personNameDelegate(this);
      }
       
    }
