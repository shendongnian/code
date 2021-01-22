    public class BarEncapsulator
    {
      private Bar _bar;
      internal BarEncapsulator(Bar myBar) { _bar = myBar; }
      public string BarString { get { return _bar.MyString; } }
    }
