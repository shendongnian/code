    public ShellViewModel : ViewModel
    {
         public ObservableCollection<object> MainViews
         {
              ...
         }
    
         public ShellViewModel()
         {
              MainViews = new ObservableCollection<object>(ViewRegistry.Select(factory => factory()));
         }
    }
