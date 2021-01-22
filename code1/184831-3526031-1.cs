    public partial class MainWindow : Window
    {
        ObservableCollection<UserButtons> oc;
        
        public MainWindow()
        {
            InitializeComponent();
    
            oc = new ObservableCollection<UserButtons>()
            {
                new UserButtons() { Button1="UserButton1", Button2 = "UserButton2"},
                new UserButtons() { Button1="Cheese", Button2 = "Wine"},
                new UserButtons() { Button1="Wallace", Button2 = "Gromit"},
            };
    
            this.itemsControl.ItemsSource = oc;
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            oc.Add(new UserButtons() { Button1 = "NewButton1", Button2 = "NewButton2" });
        }
    }
    
    public class UserButtons : INotifyPropertyChanged
    {
        private string button1;
        public string Button1
        {
            get { return this.button1; }
            set
            {
                this.button1 = value;
                this.OnPropertyChanged("Button1");
            }
        }
    
        private string button2;
        public string Button2
        {
            get { return this.button2; }
            set
            {
                this.button2 = value;
                this.OnPropertyChanged("Button2");
            }
        }
    
        #region INotifyPropertyChanged Members
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    
        #endregion
    }
