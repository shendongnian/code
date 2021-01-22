    public abstract class Person
       {
          public abstract string Name
          {
             get;
             set;
          }
          public abstract int Age
          {
             get;
             set;
          }
       }
    // overriden something like this
    // Declare a Name property of type string:
      public override string Name
      {
         get
         {
            return name;
         }
         set
         {
            name = value;
         }
      }
