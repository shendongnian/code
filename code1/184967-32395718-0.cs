    SqlConnection con = new SqlConnection(@"Some Connection String");//connection object
    SqlDataAdapter da = new SqlDataAdapter("ParaEmp_Select",con);//SqlDataAdapter class object
    da.SelectCommand.CommandType = CommandType.StoredProcedure; //command sype
    da.SelectCommand.Parameters.Add("@Contactid", SqlDbType.Int).Value = 123; //pass perametter
    DataTable dt = new DataTable();  //dataset class object
    da.Fill(dt); //call the stored producer
