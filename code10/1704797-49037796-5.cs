    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MainViewModel(IDataService dataService)
        {
            BackColor = Brushes.Aqua;
            DoOnTextChanged = new EventCommand((obj => BackColor = BackColor == Brushes.BurlyWood ? Brushes.Chartreuse : Brushes.BurlyWood));
        }
        public ICommand DoOnTextChanged { get; set; }
        private Brush backColor;
        public Brush BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                backColor = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("BackColor"));
                }
            }
        }
    }
