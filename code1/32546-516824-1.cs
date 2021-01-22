    OdbcConnection cn;
    OdbcCommand cmd;
    OdbcParameter prm;
    OdbcDataReader dr;
    
    try {
        //Change the connection string to use your SQL Server.
        cn = new OdbcConnection("Driver={SQL Server};Server=servername;Database=Northwind;Trusted_Connection=Yes");
    
        //Use ODBC call syntax.
        cmd = new OdbcCommand("{call CustOrderHist (?)}", cn);
    
        prm = cmd.Parameters.Add("@CustomerID", OdbcType.Char, 5);
        prm.Value = "ALFKI";
    
        cn.Open();
    
        dr = cmd.ExecuteReader();
    
        //List each product.
        while (dr.Read()) 
    	Console.WriteLine(dr.GetString(0));
    
        //Clean up.
        dr.Close();
        cn.Close();
    }
    catch (OdbcException o) {
        MessageBox.Show(o.Message.ToString());
    }
