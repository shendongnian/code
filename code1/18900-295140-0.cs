    public class Person
    {
       private string _name;
       public string Name
       {
          get
          {
             return _name;
          }
          set
          {
             _name = value;
          }
       }
       public int Age{get;set;} //AutoProperty generates private field for us
    }
