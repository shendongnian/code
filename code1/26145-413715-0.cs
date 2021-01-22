      public class MyFooCollection: Collection<string>
       {
          public MyFooCollection(string[] values)
          {
              foreach (string s in values)  base.Add(s); 
          }
       }
