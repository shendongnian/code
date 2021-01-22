    string xlPath = @"D:\Temparary.xlsx";    //location of xlsx file
    
    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + xlPath + ";Extended Properties=\"Excel 12.0 Xml; HDR=YES; IMEX=1;\"";
    
    OleDbConnection con = new OleDbConnection(constr);
    
    OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]",con);
    
    con.Open();
    
    OleDbDataReader dreader = cmd.ExecuteReader();
    
    if (dreader.HasRows)
    {
        dreader.Read();
        Label2.Text = dreader.GetValue(0).ToString();
    
    }
    
    dreader.Close();
    
    con.Close();
