    namespace WPFListBoxSample {
    public partial class Window1 : Window
{
        WPFListBoxModel model = new WPFListBoxModel();
        public Window1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
        }
        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
            this.DataContext = model;
        }
        public void GetData()
        {
            //SqlConnection myConnection = new SqlConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "ProgramsList.sdf");
            SqlConnectionStringBuilder str = new SqlConnectionStringBuilder();
            str.DataSource="192.168.1.27";
            str.InitialCatalog="NorthWnd";
            str.UserID="sa";
            str.Password="xyz";
            SqlConnection myConnection = new SqlConnection(str.ConnectionString);
            SqlDataReader myReader = null;
            myConnection.Open();
            SqlDataReader dr = new SqlCommand("SELECT CategoryId, CategoryName FROM Categories ORDER BY CategoryName DESC", myConnection).ExecuteReader();
            while (dr.Read())
            {
                model.Categories.Add(new Category { Id = dr.GetInt32(0), CategoryName = dr.GetString(1) });
            }
            myConnection.Close();
        }
        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.myCombo.SelectedValue != null)
                MessageBox.Show("You selected product: " + this.myCombo.SelectedValue);
            else
                MessageBox.Show("No product selected");
        }
    }
