    static void Main(string[] args)
    {
      Excel.Application ExcelApp = new Excel.Application();
      DoSomething(ExcelApp);
      
      Console.WriteLine("Input a digit: ");
      int k = Console.Read(); 
      Quit(ExcelApp);
    }
