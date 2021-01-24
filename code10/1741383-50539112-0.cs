            var ds = new DataSet();
            var dataTable = new DataTable("DataTable");
            var stringCol = new DataColumn("String Column", typeof(string));
            var intCol = new DataColumn("Integer Column", typeof(int));
            var decimalCol = new DataColumn("Decimal Column", typeof(decimal));
            dataTable.Columns.AddRange(new [] {stringCol, intCol, decimalCol});
            var newRow = new object[]
            {
                "String item",
                1,
                100.08m
            };
            dataTable.Rows.Add(newRow);
            ds.Tables.Add(dataTable);
            var row = ds.Tables["DataTable"].Rows[0];
            var stringRowValue = row["String Column"];
            var intRowValue = row["Integer Column"];
            var decimalRowValue = row["Decimal Column"];
            Console.WriteLine($"String value: {stringRowValue}\nInteger value: {intRowValue}\nDecimal Value: {decimalRowValue}");
            var rowArr = new DataRow[ds.Tables["DataTable"].Rows.Count];
            ds.Tables["DataTable"].Rows.CopyTo(rowArr, 0);
            var list = rowArr.ToList();
            foreach (DataRow rowitem in list)
            {
                Console.WriteLine($"\nFrom List: String value: {rowitem["String Column"]}\nInteger value: {rowitem["String Column"]}\nDecimal Value: {rowitem["String Column"]}");
            }
            Console.ReadKey();
