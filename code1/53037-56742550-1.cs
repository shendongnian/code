    void Demo1()
    {
       const string code = @"
       public class Runner
       {
          public void Run() { System.IO.File.AppendAllText(@""C:\Temp\NUnitTest.txt"", System.DateTime.Now.ToString(""o"") + ""\n""); }
       }";
       
       CSharpRunner.Run(code, null, "Runner", "Run");
    }
    
    void Demo2()
    {
       CSharpRunner.Run(typeof(Runner).GetMethod("Run"));
    }
    
    public class Runner
    {
       public void Run() { System.IO.File.AppendAllText(@"C:\Temp\NUnitTest.txt", System.DateTime.Now.ToString("o") + "\n"); }
    }
