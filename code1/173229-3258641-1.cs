    public static void Main()
    {
      var test1 = new Source();
      test1.Event += (sender, args) => { Console.WriteLine("Hello World"); };
      test1 = null;
      GC.Collect();
      GC.WaitForPendingFinalizers();
    
      var test2 = new Source();
      test2.Event += test2.Handler;
      test2 = null;
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }
    
    public class Source()
    {
      public event EventHandler Event;
    
      ~Source() { Console.WriteLine("disposed"); }
    
      public void Handler(object sender, EventArgs args) { }
    }
