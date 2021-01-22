    using System.Data.OleDb;
    ...
    private void DoIt()
    {
      OleDbConnection NamesDB = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CyberSprocket.mdb");
    
      try
      {
         NamesDB.Open();
      }
      catch (Exception ex) {
          MessageBox.Show(ex.Message);
          return;
      }
      OleDbCommand NamesCommand = new OleDbCommand("SELECT * FROM [names];", NamesDB);
      OleDbDataReader dr = NamesCommand.ExecuteReader();
    
      string theColumns = "";
      for (int column = 0; column < dr.FieldCount; column++)
      {
        theColumns += dr.GetName(column) + " | ";
      }
      MessageBox.Show(theColumns);
    
      NamesDB.Close();
    }
