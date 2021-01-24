               List<DataTable> deptTables = dt
                    .AsEnumerable()
                    .GroupBy(x => x.Field<int>("DeptId"))
                    .Select(x => x.CopyToDataTable())
                    .ToList();
     
