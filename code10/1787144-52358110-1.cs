     public void deleteRow(Row myRow) {
        deleteRowInternal(myRow);
        Events.OnRemoveRow(myRow);
    }
    private void deleteRowInternal(Row myRow) {
         // do some control on myRow
        if (!(myRow.hasThatValue()) && 
         (myRow.Title.StartsWith("xxx"))
             return;
        Rows.Remove(myRow);
    }
     public void deleteRows(List<Row> myRows) {
           foreach (var r in myRows) {
           deleteRowInternal(r); 
         }
         Events.OnReloadTable();
     }
