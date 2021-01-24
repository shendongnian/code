    DataTable HasDuplicates = dt.AsEnumerable()
                              .GroupBy(g => g["Empolyee_CRC"])
                              .Where(c => c.Count() > 1)
                              .Select(g => g
                                    .OrderBy(r => r["Empolyee_CRC"])
                                    .Select(r => r["Empolyee_CRC"])
                                    .First())
                              .CopyToDataTable();
