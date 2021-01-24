    // Let's change List<T> into more generic IEnumerable<T>
    void deleteRows(IEnumerable<Row> myRows) {
       // Readbility: let's put it clear what we are going to remove
       var toRemove = myRows
         .Where(row => !row.Title?.StartsWith("xxx"))
         .Where(row => row.hasThatValue());
    
       // If you have RemoveRange in Rows collection - remove in one go
       // Rows.RemoveRange(toRemove);
     
       // If you don't have RemoveRange method, let's loop
       foreach (var r in toRemove)
         Rows.Remove(r);
    
       Events.OnReloadTable();     // That call only one time OnReloadTable()
    }
    
    // Taken from Mureinik's answer (except the collection class wrapper)
    void void deleteRow(Row myRow) {
      deleteRows(new Row[] {myRow}); 
    }
