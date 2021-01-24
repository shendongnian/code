    var result = from a in new DataContext().DataColumn
                     where a.ColumnName != "ID"
                     select new {a.NotForExcel, a.ExcelColumn1, a.ExcelColumn2 };
        
    var ExcelList = result.AsEnumerable()
                                  .Select(o => new DataColumn {
                                                   Column1 = o.ExcelColumn1, 
                                                   Column2 = o.ExcelColumn2 
                                  }).ToList();
