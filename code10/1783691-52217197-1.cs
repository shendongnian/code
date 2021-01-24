    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadUserCB();
        }
        private void loadUserCB()
        {
            SqlDbConnect sdc = new SqlDbConnect();
            DataSet ds = new DataSet();
            sdc.SqlQuery("select * from TUser");
            ds=sdc.QueryEx("TUserDS");
            UserCB.DataContext = ds;
            //Here, the ComboBox just set ItemsSource
            //But you haven't set an selected item
            //ComboBox won't auto select anything after reset ItemsSource
            //Even if you're set it in xaml
            string selUserName = UserCB.SelectedItem.ToString(); //this code failed to get the selected item
        }
    }
