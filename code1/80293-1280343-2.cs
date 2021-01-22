    namespace ConsoleApplication
    {
      class Program
      {
        static void Main (string [] args)
        {
          CSLibrary.CSClass a = new CSLibrary.CSClass ();
          CSLibrary.CSClass.ACSharpDelegate dlg = new CSLibrary.CSClass.ACSharpDelegate (a.Hello);
    
          CPPLibrary.CPPClass b = new CPPLibrary.CPPClass ();
          String result = b.UseDelegate (dlg);
    
          Console.WriteLine (result);
          Console.Read ();
        }
      }
    }
