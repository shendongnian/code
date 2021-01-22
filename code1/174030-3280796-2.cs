    public sealed class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Strings { get; private set; }
    
        public ICommand SelectString { get; private set; }
    
        public string SelectedString { get; set; }
    
        public ViewModel()
        {
            Strings = new ObservableCollection<string>();
            Strings.Add("Foo");
            Strings.Add("Bar");
            Strings.Add("Baz");
            SelectString = new SelectStringCommand
            {
                ExecuteCalled = SelectBar
            };
        }
    
        private void SelectBar()
        {
            SelectedString = "Bar";
            // bad practice in general, but this is just an example
            PropertyChanged(this, new PropertyChangedEventArgs("SelectedString"));
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
    
    /// <summary>
    /// ICommands connect the UI to the view model via the commanding pattern
    /// </summary>
    public sealed class SelectStringCommand : ICommand
    {
        public Action ExecuteCalled { get; set; }
    
        public bool CanExecute(object parameter)
        {
            return true;
        }
    
        public event EventHandler CanExecuteChanged;
    
        public void Execute(object parameter)
        {
            ExecuteCalled();
        }
    }
