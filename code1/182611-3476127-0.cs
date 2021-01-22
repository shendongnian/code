    private void GetRowsByFilter(){
       DataTable myTable;
       myTable = DataSet1.Tables["Orders"];
       // Presuming the DataTable has a column named Date.
       string strExpr;
       strExpr = "Date > '1/1/00'";
       DataRow[] foundRows;
       // Use the Select method to find all rows matching the filter.
       foundRows = myTable.Select(strExpr);
       // Print column 0 of each returned row.
       for(int i = 0; i < foundRows.Length; i ++){
          Console.WriteLine(foundRows[i][0]);
       }
    }
