    using System;
    
    public class Test {
     enum Names {
      Jack = 1,
       Alice,
       Stiven,
       Alex,
       Katrin
     };
     public static void Main() {
    
      string Name = "Alex";
      Names eName;
      Enum.TryParse < Names > (Name, out eName);
      Console.WriteLine((int) eName);
     }
    }
