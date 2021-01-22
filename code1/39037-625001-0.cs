    void CreateExcelDocThroughAdoNet()
    {
        const string Filename= "adonet-excel.xls";
  
        const string strConnect = 
          "Provider=Microsoft.Jet.OLEDB.4.0;" + 
          "Data Source=" + Filename + ";" + 
          "Extended Properties=\"Excel 8.0;HDR=yes;\""; 
        try
        {
          conn = new System.Data.OleDb.OleDbConnection(strConnect);
          CreateTable();
          for(int i=0; i < 4; i++) Insert(i);
        }
        catch (System.Exception ex)
        {
          System.Console.WriteLine("Exception: " + ex.Message+ "\n  " + ex.StackTrace); 
        }
    }
    private void CreateTable()
    {
        string strSql = "CREATE TABLE SampleTable ( Ix NUMBER, CustName char(255), Stamp datetime )";
      
        System.Data.OleDb.OleDbCommand cmd= new System.Data.OleDb.OleDbCommand(strSql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    private void Insert(int ix)
    {
        string strSql = "insert into [SampleTable] ([ix],[CustName],[Stamp]) value(@p1,@p2,@p3)";
      
        System.Data.OleDb.OleDbCommand cmd= new System.Data.OleDb.OleDbCommand(strSql, conn);
        cmd.Parameters.Add("@p1", System.Data.OleDb.OleDbType.Numeric).Value = ix;
        cmd.Parameters.Add("@p2", System.Data.OleDb.OleDbType.VarChar).Value = "Some text";
        cmd.Parameters.Add("@p3", System.Data.OleDb.OleDbType.Date).Value = System.DateTime.Now;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
      }
