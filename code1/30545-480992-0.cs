     public static void Test (object o) 
       {
          Class1 a;
          Class2 b;
    
          if (o is Class1) 
          {
             Console.WriteLine ("o is Class1");
             a = (Class1)o;
             // do something with a
          }
          
          else if (o is Class2) 
          {
             Console.WriteLine ("o is Class2");
             b = (Class2)o;
             // do something with b
          }
          
          else 
          {
             Console.WriteLine ("o is neither Class1 nor Class2.");
          }
       }
