    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
    
                String connectionString = "Data Source=DWH; User Id=readonly; Password=********;";
                OracleConnection con = new OracleConnection();
                con.ConnectionString = connectionString;
                con.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "SELECT * FROM SALARIES";
                cmd.Connection = con;
                OracleDataReader dr = cmd.ExecuteReader();
                DataGrid dg = new DataGrid();
                if (dr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dg.ItemsSource= dt.DefaultView;
                    }
               con.Close();
            }
            catch (Exception exp) { }
        }   
