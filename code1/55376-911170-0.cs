        OleDbConnection DBConnection = new
        OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" +
         Server.MapPath("~/App_Data/savcilik_katip.xls") + ";" + "Extended Properties=\"Excel 8.0;HDR=Yes\"");
        DBConnection.Open();
        OleDbCommand DBCommand = new OleDbCommand("SELECT * FROM [Sayfa1$]", DBConnection);
        OleDbDataAdapter da = new OleDbDataAdapter(DBCommand);
        DataSet ds = new DataSet("Nobet");
        da.Fill(ds, "Nobet");
        DBConnection.Close();
        DBConnection = new
      OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" +
      Server.MapPath("~/App_Data/savcilik_savci.xls") + ";" + "Extended Properties=\"Excel 8.0;HDR=Yes\"");
        DBConnection.Open();
        DBCommand = new OleDbCommand("SELECT * FROM [Sayfa1$]", DBConnection);
        da = new OleDbDataAdapter(DBCommand);
        da.Fill(ds, "Nobetci");
        DBConnection.Close();
        for (int i = 0; i < ds.Tables["Nobet"].Rows.Count; i++)
        {
            ds.Tables["Nobet"].Rows[i]["SAVCI"] = ds.Tables["Nobetci"].Rows[i]["SAVCI"];
        }
        GridView1.DataSource = ds.Tables["Nobet"];
        GridView1.DataBind();
