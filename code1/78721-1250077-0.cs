    public class Person {
      private String _personName;
      public String PersonName { 
        get { return _personName; }
        set { _personName = value; }
      }
    
      public String SayHello(String toName ) {
        return String.Format("Hi {0}, I am {1}", toName, PersonName);
      }
    
    }
