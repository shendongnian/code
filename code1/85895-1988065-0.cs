    // Windows presetation foundation dependency property.
    public class MyStateControl : ButtonBase
    {
      public MyStateControl() : base() { }
      public Boolean State
      {
        get { return (Boolean)this.GetValue(StateProperty); }
        set { this.SetValue(StateProperty, value); } 
      }
      public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
        "State", typeof(Boolean), typeof(MyStateControl),new PropertyMetadata(false));
    }
