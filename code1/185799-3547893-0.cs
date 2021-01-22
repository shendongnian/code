    public interface IMainView
    {
      public void UpdateValue(string val);
    }
    
    public interface IChildView
    {
      public void Show(IMainView parent);
    }
