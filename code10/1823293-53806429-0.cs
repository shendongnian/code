    public class IhaveNoStatic
    {
       public string Hello = "Hello I am B"
    }
    public class C
    {
          Console.WriteLine(IhaveStatic.Hello);    // Correct
          IhaveNoStatic obj = new IhaveNoStatic();
          Console.WriteLine(obj);                  // Correct
          Console.WriteLine(IhaveNoStatic.Hello);  // Compile time error
     }
