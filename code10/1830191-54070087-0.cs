    public void WriteDataToSheet(DataTable data)
    {
        using (ExcelPackage excel = new ExcelPackage())
        {
            ExcelWorksheet ws = excel.Workbook.Worksheets.Add("Test");
    
            ws.Cells["A1"].LoadFromDataTable(data, true);
            ws.Cells[ws.Dimension.Address].AutoFitColumns();
    
            var listObject = data.AsEnumerable()
                    .Select(x => new
                    {
                        Col1 = x.Field<string>("Col1"),
                        Col2 = x.Field<string>("Col2"),
                        Col3 = x.Field<string>("Col3")
                    }).ToList();
    
    
            var lisa = listObject.GroupBy(x => x.Col1).
                Select(x => new
                {
                    Id = x.Key,
                    Quantity = x.Count(),
                    secondGroup = x.GroupBy(y => y.Col2)
                               .Select(y => new
                               {
                                   ID = y.Key,
                                   secondGroup = y.Count()
                               })
                });
    
            int A = 1, B = 0, C = 1, D = 0;
            foreach (var item in lisa)
            {
                B = A + 1;
                A += item.Quantity;
                ws.Cells["A" + B + ":A" + A + ""].Merge = true;
                ws.Cells["B" + B + ":B" + A + ""].Merge = true;
    
                foreach (var item2 in item.secondGroup)
                {
                    D = C + 1;
                    C += item2.secondGroup;
                    ws.Cells["C" + D + ":C" + C + ""].Merge = true;
                }
            }
            // Save merged and modified file to the location
        }
    }
