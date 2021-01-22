      // fill data from SQL
      var ConnSql= new System.Data.OleDb.OleDbConnection(ConnStringSql);
      var da1 = new System.Data.OleDb.OleDbDataAdapter();
      da1.SelectCommand=  new System.Data.OleDb.OleDbCommand(sqlSelect);
      da1.SelectCommand.Connection= ConnSql;
      var ds1 = new System.Data.DataSet();
      da1.Fill(ds1, "Extracto");
      // need to update the rows so the DA does the insert...
      foreach (System.Data.DataRow r in ds1.Tables[0].Rows) { 
        r["Extracted"]= System.DateTime.Now; // update one column in each row
      }
      // insert into Excel
      var ConnExcel= new System.Data.OleDb.OleDbConnection(ConnStringExcel);
      var da2 = new System.Data.OleDb.OleDbDataAdapter();
      da2.UpdateCommand= new System.Data.OleDb.OleDbCommand(sqlInsert);
      da2.UpdateCommand.Connection= ConnExcel;
      da2.UpdateCommand.Parameters.Add("@ProductId", System.Data.OleDb.OleDbType.Integer, 4, "ProductId");
        ..etc..
      da2.Update(ds1, "Extracto");
