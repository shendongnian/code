    /// <summary>
    /// Interaction logic for TextBoxUsercontrol.xaml
    /// </summary>
    public partial class TextBoxUsercontrol : UserControl, INotifyPropertyChanged
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }
        }
        public TextBoxUsercontrol()
        {
            DataContext = this;
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
