    class ViewModel : INotifyPropertyChanged
    {
        public ICommand myCommand { get; set; }
        private string _title = "This is a textblock";
        public string Title { get { return _title; } }
        public ViewModel()
        {
            myCommand = new myCommand(ExecutedMethod);
        }
        private void ExecutedMethod (object parameter)
        {
            _title = "Button 1 was clicked";
            OnPropertyChanged("Title");
        }
    }
