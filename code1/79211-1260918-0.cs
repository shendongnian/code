DataTable datatable = new DataTable();
DataColumn titleCol = new DataColumn("title", Type.GetType("System.String"));
datatable.Columns.Add(titleCol);
foreach(name in names)
{
   DataRow newRow = new DataRow();
   newRow["title"] = name;
   /*
    * Add the rows you want into your data table
    */
   datatable.Rows.Add(newRow);
}
