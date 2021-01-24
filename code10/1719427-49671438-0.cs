    public EnumerableRowCollection<DataRow> GetSortedRows(DataTable dataRows)
        {
            
                var collection = dataRows.AsEnumerable();
               return collection.OrderByDescending(r => r["Name"]);           
            
        }
