     class MyViewModel
    {
        public MyViewModel()
        {
            MyCommand = new ICommandImplementation();
        }
        public ObservableCollection<string> MyData
        {
            get
            {
                return new ObservableCollection<string>(new string[]{
                "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", 
                "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty"
                });
            }
        }
        public ICommand MyCommand { get; private set; }
        private class ICommandImplementation : ICommand
        {
            public bool CanExecute(object parameter) { return true; }
            public event EventHandler CanExecuteChanged;
            public void Execute(object parameter) { System.Windows.MessageBox.Show("Button clicked! " + (parameter ?? "").ToString()); }
        }
    }
