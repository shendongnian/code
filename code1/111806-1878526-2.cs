    // Simplified example to explain:
    
    public interface IPrint 
    { 
       public void Print(string); 
    }
    
    public class PrintA : IPrint
    {
       public void Print(string input)
       { ... format as desired for A ... }
    }
    
    public class PrintB : IPrint
    {
       public void Print(string input)
       { ... format as desired for B ... }
    }
    
    class MyPage
    {
       IPrint printer;
    
       public class MyPage(bool usePrintA)
       {
          if (usePrintA) printer = new PrintA(); else printer = new PrintB();
       }
    
       public PrintThePage()
       {
          printer.Print(thePageText);
       }
    }
