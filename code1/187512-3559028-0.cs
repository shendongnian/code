    var myConnection = new SqlConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "ProgramsList.sdf");
    var cmd = new SqlCommand("SELECT Name FROM CategoryList ORDER BY Name DESC", myConnection);
    
    myConnection.Open();
    CategoryList.Items.Clear();
    
    var sda = new SqlDataAdapter(cmd);
    var ds = new DataSet();
    sda.Fill(ds);
    
    CategoryList.ItemsSource = ds.Tables["CategoryList"];
    
    myConnection.Close(); 
