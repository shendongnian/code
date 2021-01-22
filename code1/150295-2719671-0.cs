      ng connStringAcces = ConfigurationManager.ConnectionStrings["RandAppAcces"].ToString();
      connAcces = new OleDbConnection(connStringAcces);
      
      daAcces = new OleDbDataAdapter();
      
      string sqlSelectAcces = "SELECT * FROM tblPrinter";
      OleDbCommand cmdAcces = new OleDbCommand(sqlSelectAcces, connAcces);
      daAcces.SelectCommand = cmdAcces;
      string connStringMDF = ConfigurationManager.ConnectionStrings["RandAppMDF"].ToString();
      connMDF = new SqlConnection(connStringMDF);
      daMDF = new SqlDataAdapter();
      string sqlSelectMDF = "SELECT * FROM tblPrinter";
      SqlCommand cmdMDF = new SqlCommand(sqlSelectMDF, connMDF);
      daMDF.SelectCommand = cmdMDF;
      string sqlInsertMDF = @"INSERT INTO tblPrinter(PRINTER_ID, MERK, MODEL, LOKAAL_ID)" +
        @"VALUES (@PRINTER_ID, @MERK, @MODEL, @LOKAAL_ID)";
      cmdMDF = new SqlCommand(sqlInsertMDF, connMDF);
      cmdMDF.Parameters.Add("@PRINTER_ID", SqlDbType.Int, 0, "PRINTER_ID");
      cmdMDF.Parameters.Add("@MERK", SqlDbType.NVarChar, 100, "MERK");
      cmdMDF.Parameters.Add("@MODEL", SqlDbType.NVarChar, 100, "MODEL");
      cmdMDF.Parameters.Add("@LOKAAL_ID", SqlDbType.Int, 0, "LOKAAL_ID");
       daMDF.InsertCommand = cmdMDF;
      dsMDF = new DataSet();
      dsAcces = new DataSet();
      
      daMDF.Fill(dsMDF, "dsPrinterMDF");
      daAcces.Fill(dsAcces, "dsPrinterAcces");
      DataTable tableAcces = dsAcces.Tables["dsPrinterAcces"];
      DataTable tableMDF = dsAcces.Tables["dsPrinterMDF"];
      DataRow newrow = null;
      foreach(DataRow dr in tableAcces.Rows)
       {
           newrow = tableMDF.NewRow();
        newrow["PRINTER_ID"] = dr["PRINTER_ID"];
        newrow["MERK"] = dr["MERK"];
        newrow["MODEL"] = dr["MODEL"];
        newrow["LOKAAL_ID"] = dr["LOKAAL_ID"];
        tableMDF.Rows.Add(newrow);
      }
