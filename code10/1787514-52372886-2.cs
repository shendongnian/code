    public class MainWindowVm : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
    
       [NotifyPropertyChangedInvocator]
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
       {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }
    
       public SelectorEventosViewModel SelectorEventosViewModel { get; } = new SelectorEventosViewModel();
    
       public EventFilesViewModel EventFilesViewModel { get; } = new EventFilesViewModel();
    
       public MainWindowVm()
       {
          // CRITICAL--ensures that your itemsource gets updated
          SelectorEventosViewModel.PropertyChanged += SelectorEventosViewModel_PropertyChanged;
       }
    
       private void SelectorEventosViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
       {
          // CRITICAL--ensures that your itemsource gets updated
          EventFilesViewModel.GetFiles(SelectorEventosViewModel.CurrentSelection.Key);
       }
    }
