    public class MyStateControl : ButtonBase
    {
      public MyStateControl() : base() { }
    
      [DependencyProperty(DefaultValue=true)] 
      bool State { get; set; }
    }
