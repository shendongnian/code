    void Main()
    {
      var tbl = new System.Data.DataTable();
      new SqlDataAdapter(@"
      WITH  tally ( OrderNo, UniqueId, RandNumber )
            AS (
                 SELECT TOP 50000
                        ROW_NUMBER() OVER ( ORDER BY t1.object_id ), 
                        NEWID(),
                        CAST(CAST(CAST(NEWID() AS VARBINARY(4)) AS INT) AS DECIMAL) / 1000
                 FROM   master.sys.all_columns t1
                 CROSS JOIN master.sys.all_columns t2
               )
      SELECT  OrderNo, 
        DATEADD(DAY, -OrderNo, GETDATE()) as OrnekDate, 
        UniqueId, RandNumber, 
        abs(RandNumber)%100 / 100 as pct
      FROM [tally];", @"server=.\SQLExpress;Database=master;Trusted_Connection=yes;").Fill(tbl);
    
      object[,] arr = new object[tbl.Rows.Count + 1, tbl.Columns.Count];
      for (int i = 0; i < tbl.Columns.Count; i++)
      {
        arr[0, i] = tbl.Columns[i].Caption;
      }
      for (int i = 0; i < tbl.Rows.Count; i++)
      {
        for (int j = 0; j < tbl.Columns.Count; j++)
        {
          arr[i + 1, j] = tbl.Rows[i][j].ToString(); // without .ToString() you should have the error
        }
      }
    
      // Excel dosya yarat ve arrayi koy
      Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();
      var workbook = xl.Workbooks.Add();
      xl.Visible = true;
    
     Worksheet sht = ((Worksheet)workbook.ActiveSheet);
     Range target = (Range)sht.Range[ (Range)sht.Cells[1,1], (Range)sht.Cells[arr.GetUpperBound(0)+1,arr.GetUpperBound(1)+1] ];
     target.Value2 = arr;
    
    }
 
