        String Sql = @" select * from SUPPORTTEAM";
        SqlConnection conn = new SqlConnection(Properties.Resources.cString);
        SqlDataAdapter DA = new SqlDataAdapter(Sql, 
        Properties.Resources.cString);          
        DataSet DS = new DataSet();
        DA.Fill(DS); // change here
        DataTable DT = DS.Tables[0]; // and here
        
        DropDownList1.DataValueField = "SupportTeamID";
        DropDownList1.DataTextField = "SupportTeamName";
        DropDownList1.DataSource = DT;
