    public partial class MainPage : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Customer> _MyList = 
            new ObservableCollection<Customer>();
        public ObservableCollection<Customer> MyList
        {
            get { return _MyList; }  
        } 
        public MainPage()
        {                      
            InitializeComponent();
            
            this.DataContext = this;
            MyList.Add(new Customer{ _nome = "Josimari", _idade = "29"});
            MyList.Add(new Customer{_nome = "Wesley", _idade = "26"});
            MyList.Add(new Customer{_nome = "Renato",_idade = "31"});
            OnPropertyChanged("MyList"); // This only works if you use bindings.
        }
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MyList.Add(new Customer{_nome = "Maiara",_idade = "18"});   
            OnPropertyChanged("MyList"); // This only works if you use bindings.
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged( string propertyName )
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
    }
      
