       public class ViewModelBase : INotifyPropertyChanged
    {
        private List<String> _printer = new List<string>();
        private bool _canExecute;
        public ViewModelBase()
        {
            _canExecute = true;
        }
        public List<string> Printers
        {
            get { return _printer; }
            set { _printer = value; }
        }
 
        private ICommand _SelectedItemChangedCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
  
        public ICommand SelectedItemChangedCommand
        {
            get
            {
                return _SelectedItemChangedCommand ?? (_SelectedItemChangedCommand =
                           new CommandHandler(obj => SelectedItemChangedHandler(obj), _canExecute));
            }
        }
   
        public void SelectedItemChangedHandler(object param)
        {
            var selectedItem = ((ComboBoxItem)param).Content;
            switch (selectedItem)
            {
                case "Hospital":
                    Printers = new List<string>(); //clearing the list;
                                                   // Hospital = GetHospital();// - ComputerName \\bmh01 - print01 | where { ($_.Name - like “*BMH01 *”) -and($_.DeviceType - eq "Print")}
    
    // Here I have added data hard coded, you need to call your method and assgin it to printers property.
                    Printers.Add("First Floor Printer");
                    Printers.Add("Second Floor Printer");
                    OnPropertyChanged(nameof(Printers));
                    break;
                default:
                    Printers = new List<string>();
                   break;
            }
        }
    }
