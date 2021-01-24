    private void searchButton_Click(object sender, RoutedEventArgs e)
    {
    	string sqlStr = "SELECT RentalId,TruckId,CustomerID,TotalPrice,RentDate,ReturnDueDate FROM TruckRental where JoiningDate between @fromDt AND @toDt";
    	string connStr = @"Data Source = xmsql04.australiaeast.cloudapp.azure.com,6302 ;Initial Catalog=DAD_TruckRental_RGM;Persist Security Info=True;User ID=DDQ4_Melveena;Password=fBit$73939";
    	using (SqlConnection con = new SqlConnection(connStr))
    	using (SqlDataAdapter sda = new SqlDataAdapter(sqlStr, con))
    	{
    		sda.SelectCommand.Parameters.Add(new SqlParameter("@toDt", SqlDbType.DateTime)).Value = toText1.SelectedDate.Value;
    		sda.SelectCommand.Parameters.Add(new SqlParameter("@fromDt", SqlDbType.DateTime)).Value = fromText.SelectedDate.Value;
    
    		DataSet ds = new DataSet();
    		con.Open();
    		sda.Fill(ds, "TruckRental");
    		gridView2.ItemsSource = ds.DefaultViewManager;
    	}
    }
