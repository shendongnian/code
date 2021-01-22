    public static class ViewModelLocator
    {
      public static MainWindowViewModel MainWindowViewModel
      {
        get 
        {
          return ObjectFactory.GetInstance<MainWindowViewModel>(); 
        }
      }
    };
