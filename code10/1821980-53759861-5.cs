    DataTable dtResult = new DataTable();
    dtResult.Columns.Add("Empolyee_CRC");
    
    DataTable HasDuplicates = dt.AsEnumerable()
                                .GroupBy(g => g["Empolyee_CRC"])
                                .Where(c => c.Count() > 1)
                                .OrderBy(x => x.Key)
                                .Select(g => dtResult.LoadDataRow(new object[] { g.FirstOrDefault().Field<string>("Empolyee_CRC") }, false))
                                .CopyToDataTable();
