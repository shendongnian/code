     public partial class MainWindow : Window
    {
        ButtonGroupsController MyButtonGroups = new ButtonGroupsController();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MyButtonGroups;
            MyButtonGroups.Group1Enable = false;
            MyButtonGroups.Group2Enable = true;
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyButtonGroups.Group1Enable = !MyButtonGroups.Group1Enable;
            MyButtonGroups.Group2Enable = !MyButtonGroups.Group2Enable;
        }
    }
    public class ButtonGroupsController : INotifyPropertyChanged
    {
        private bool group1Enable = false;
        private bool group2Enable = false;
        public bool Group1Enable
        {
            get
            {
                return group1Enable;
            }
            set
            {
                group1Enable = value;
                if (PropertyChanged!=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Group1Enable"));
                }
            }
        }
        public bool Group2Enable
        {
            get
            {
                return group2Enable;
            }
            set
            {
                group2Enable = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Group2Enable"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
