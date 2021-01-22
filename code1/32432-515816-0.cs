    public class Person
    {
      internal Person()
      {
      }
    }
    
    public class PersonFactory
    {
      public Person Create()
      {
        return new Person();
      }  
    }
