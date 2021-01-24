    public class ViewModelBase : INotifyPropertyChanged
    {
        private string _s;
        public string Sname
        {
            get { return _s; }
            set
            {
                _s = value;
                onPropertyChanged("Sname");
            }
        }
        public ViewModelBase()
        {
            TheCommand = new SetYesCommand(OnCommandExecuted, null);
        }
        private void OnCommandExecuted(object parameter)
        {
            Sname = "Yes";
            MessageBox.Show("Command works");
        }
        public ICommand TheCommand { get; private set; }
        private void onPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
