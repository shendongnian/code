        public labelControl()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                RefreshLabel();
            }
        }
        private async void RefreshLabel()
        {
            await Task.Run(() => {
                while (true)
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
                                            ChangeLabelText(sqlReader["Text"].ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    System.Threading.Thread.Sleep(500); // time to sleep thread
                }
            });
        }
        private void ChangeLabelText(string value)
        {
            if (label1.InvokeRequired)
            {
                label1.Invoke(new Action<string>(ChangeLabelText), value);
                return;
            }
            label1.Text = value;
        }
