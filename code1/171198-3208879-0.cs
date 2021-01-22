    private class MyControl : INotifyPropertyChanged
    {
        private string _myProperty;
        public string MyProperty
        {
            get
            {
                return _myProperty;
            }
            set
            {
                if (_myProperty != value)
                {
                    _myProperty = value;
                    // try to remove this line
                    NotifyPropertyChanged("MyProperty");
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    private MyControl myControl;
    
    public Form1()
    {
        myControl = new MyControl();
        InitializeComponent();
        this.DataBindings.Add("Text", myControl, "MyProperty");
    }
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        myControl.MyProperty = textBox1.Text; 
    }
