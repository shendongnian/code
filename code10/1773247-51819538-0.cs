    DataSet ds = new DataSet("peopleData");
    using(SqlConnection conn = new SqlConnection("ConnectionString"))
    {               
            SqlCommand sqlComm = new SqlCommand("get_ID", conn);               
            sqlComm.Parameters.AddWithValue("@ID", textBoxID.Text);
            sqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(ds);
     }
