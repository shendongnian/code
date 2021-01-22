    public class TestViewModel : IRaisePropertyChanged
    {
      public TestViewModel()
      {
        this.m_nameProperty = new NotifyProperty<string>(this, nameof(Name), null);
      }
      private readonly NotifyProperty<string> m_nameProperty;
      public string Name
      {
        get
        {
          return m_nameProperty.Value;
        }
        set
        {
          m_nameProperty.SetValue(value);
        }
      }
      // Plus implement IRaisePropertyChanged (or extend BaseViewModel)
    }
