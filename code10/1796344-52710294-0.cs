    try
    {
           int totalincome=600;
            int totaldeductions = 10;
            connectionString = ConfigurationManager.ConnectionStrings["BudgetApp.Properties.Settings.MainDataBaseConnectionString"].ConnectionString;
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand(@"INSERT INTO Totals(TotalIncome, TotalDeductions) VALUES (@TotalIncome, @TotalDeductions)", con);
        
            cmd.Parameters.Add("@Number", SqlDbType.Int).Value = totalincome;
            cmd.Parameters.Add("@Number", SqlDbType.Int).Value = totaldeductions;
            //cmd.Parameters.AddWithValue("@TotalIncome", totalincome);
            //cmd.Parameters.AddWithValue("@TotalDeductions", totaldeductions);
        
            cmd.ExecuteNonQuery();
    }
    catch(Exception ex)
    {
      MessageBox.Show(ex.ToString());
    }
