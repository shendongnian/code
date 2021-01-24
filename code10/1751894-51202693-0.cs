    Excel.Application excel= new Excel.Application(); 
    private System.Data.DataTable GetData()
    {
    SqlConnection conn= new SqlConnection(@"server=(local)\vste;uid=sa;pwd=;database=northwind;");
    SqlDataAdapter adapter= new SqlDataAdapter("select * from Customers",conn);
    DataSet myDataSet= new DataSet();
    try {
    adapter.Fill(myDataSet,"Customer");
    }
    catch(Exception ex) {
    MessageBox.Show(ex.ToString());
    }
    return myDataSet.Tables[0];
    } 
    foreach(DataColumn col in table.Columns)
    {
    colIndex++; excel.Cells[1,colIndex]=col.ColumnName;
    }
    foreach(DataRow row in table.Rows) {
    rowIndex++; colIndex=0;
    foreach(DataColumn col in table.Columns) {
    colIndex++; excel.Cells[rowIndex,colIndex]=row[col.ColumnName].ToString();
    }
    } 
