    private static void DemonstrateDataView(){
       // Create one DataTable with one column.
       DataTable myTable = new DataTable("myTable");
       DataColumn colItem = new DataColumn("item",typeof(DateTime));
      
      myTable.Columns.Add(colItem);
       // Add five items.
       DataRow NewRow;
       for(int i = 0; i <5; i++){
          NewRow = myTable.NewRow();
          NewRow["item"] = DateTime.Now.AddDays(-i);
          myTable.Rows.Add(NewRow);
       }
       myTable.AcceptChanges();
       // Print current table values.
       PrintTableOrView(myTable,"Current Values in Table");
    
       DataView secondView = new DataView(myTable);
       secondView.Sort = "item";
       
       PrintTableOrView(secondView, "Second DataView: ");
    }
