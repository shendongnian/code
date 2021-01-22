    public class BarProvider
    { BaseClass _source;
      Bar _currentBar;
    
      public void setSource(BaseClass b)
      {
        _source = b;
        _currentBar = b.Bar;
      }
    
      public Bar getBar()
      { return _currentBar;  }
    }
