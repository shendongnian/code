    namespace UnitTest
    {
      class Program
      {
        static void Main(string[] args_)
        {
          // run unit test
          AutoRunner auto = new AutoRunner();
          auto.Load();
          auto.Run();
    
          HtmlReport report = new HtmlReport();
          
          string fileName;
          // generate report results
          fileName = report.Render(auto.Result);
          // launch results in user's browser
          System.Diagnostics.Process.Start(fileName);
        }
      }
    }
