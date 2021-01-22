    SqlConnection conn = new SqlConnection(connString);
    string sSQL = "SELECT TEST_ID FROM TEST_TABLE";
    
    DataTable dt = new DataTable();
    SqlDataAdapter sda = new SqlDataAdapter(sSQL, conn);
    // fill the DataTable - now you should have rows and columns!
    sda.Fill(dt);
    
    // one you've filled your DataTable, you should be able
    // to iterate over it and change values
    foreach (DataRow row in dt.Rows)
    {
        row["TEST_ID"] = "changed"; //Not changing it?!
    }
    
    GridView1.DataSource = dt;
    GridView1.DataBind();
