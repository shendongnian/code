     public class Person
     {
         public string Name {get;}
     }
     public class PersonType2 : Person
     {
          private string something;
          public override string Name
          {
              get
              {
                 return something;
              }
              set
              {
                 something = value;
              }
          }
     }
     public class PersonType2 : Person
     {
          private string somethingElse;
          public override string Name
          {
              get
              {
                 return somethingElse;
              }
              set
              {
                 somethingElse = value;
              }
          }
     }
     
     public class Client
     {
         public int Compare(Client __c1, Client __c2)
         {
             return __c1.Pers.Name.CompareTo(__c2.Pers.Name);
         }
    }
