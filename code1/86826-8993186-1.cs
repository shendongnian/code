    using ADOX; //Requires Microsoft ADO Ext. 2.8 for DDL and Security
    using ADODB;
    public bool CreateNewAccessDatabase(string fileName)
    {
      bool result = false; 
      ADOX.Catalog cat = new ADOX.Catalog();
      ADOX.Table table = new ADOX.Table();
      //Create the table and it's fields. 
      table.Name = "Table1";
      table.Columns.Append("Field1");
      table.Columns.Append("Field2");
      try
      {
        cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + "; Jet OLEDB:Engine Type=5");
        cat.Tables.Append(table);
        //Now Close the database
        ADODB.Connection con = cat.ActiveConnection as ADODB.Connection;
        if (con != null)
        con.Close();
        result = true; 
      }
      catch (Exception ex)
      {
        result = false;
      }
      cat = null;
      return result;
    } 
