    public partial class labelControl : UserControl
    {
        private const short interval = 5;
        private Timer timer;
        public labelControl()
        {
            InitializeComponent();
            timer = new Timer()
            timer.Interval = interval * 1000; //time to refresh the label in seconds
            timer.Tick += updateLabel;
            timer.Start();
        }
    
        private void updateLabel()
        {  
            try
            {
            using (Database.sqlConnection = new SqlConnection(Database.connectionString))
            {
                Database.sqlConnection.Open();
                string selectQuery = "SELECT Text FROM Information WHERE ID = (SELECT MAX(ID) FROM Information)"; // you probably want the latest value
                using (SqlCommand sqlCommand = new SqlCommand(selectQuery, Database.sqlConnection))
                {
                    using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                label1.Text = sqlReader["Text"].ToString();
                            }
                        }
                    }
                }
            }
            }
            catch()
            {
                //do nothing
            }
        }
    }
