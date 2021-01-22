    class Person
    {
      public string Name{get;set;}
      public void Walk() {/*code elided*/}
    }
    
    class Employee : Person
    {
      public int Id{get;private set;}
    }
