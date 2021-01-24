    for (var i = 0; i < ds.Tables.Count; i++)
            {
                var sheetName = i < sheetNames.Count
                   ? sheetNames[i]
                   : String.Format("Sheet{0}", sheetNames.Count - i);
                var ws = package.Workbook.Worksheets.Add(sheetName);
    
                ws.Cells["A1"].LoadFromDataTable(i == 0 
                         ? Transpose(ds.Tables[i].Copy()).DefaultView.ToTable()
                         : ds.Tables[i],true, TableStyles.Medium1);
                if (i > 0)
                {
                     ws.Cells["A:H"] = "yyyy-mm-dd";
                     ws.Column(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                }
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                
            }
