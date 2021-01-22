    public class MySpecialFunctions
    {
      public void Execute(int x) {...}
      public void Execute(string x) {...}
      public void Execute(long x) {...}
    }
    
    dynamic x = getx();
    var myFunc = new MySpecialFunctions();
    myFunc.Execute(x);
