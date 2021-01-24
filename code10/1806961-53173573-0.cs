            public MainWindow()
        {
            InitializeComponent();
            /*string sql = "SELECT * FROM brands";*/
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = new MySqlCommand("select * from brands", conn);
            conn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            dtGrid.ItemsSource = dt.DefaultView;
        }
