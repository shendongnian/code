    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                String connectionString = "Data Source=DWH; User Id=readonly; Password=*******;";
                OracleConnection con = new OracleConnection();
                con.ConnectionString = connectionString;
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM SALARIES";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DataGrid1.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
