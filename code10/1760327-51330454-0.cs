    var duplicateItems = dataTable
                  .AsEnumerable()
                  .GroupBy(r => new
                  {
                      Col1 = r.Field<String>("SAP-ID")
                  })
                  .Select(g => g.Skip(1)).SelectMany(x => x).CopyToDataTable();
    
                duplicateItems.AcceptChanges();
