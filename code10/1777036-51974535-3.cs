    using System;
    using System.Data;
    using System.IO;
    using System.Linq;
    using ExcelDataReader;
    public DataTable GetTableFromExcel(string filePath)
    {
        DataSet ds = new DataSet();
        using (var stream = System.IO.File.Open(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                ds = reader.AsDataSet();
            }
        }
        DataTable table = new DataTable();
        table.Columns.Add(new DataColumn("CustomerNr"));
        table.Columns.Add(new DataColumn("Address"));
        
        // Set column names
        for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
        {
            ds.Tables[0].Columns[i].ColumnName = ds.Tables[0].Rows[0][i].ToString();
        }
        // Remove the first row containing the headers
        ds.Tables[0].Rows.Remove(ds.Tables[0].Rows[0]);
        // I don't have the benchmarks with me right now, but I've tested
        // DataTable.Select vs DataTable.AsEnumerable.Select many times
        // and the AsEnumerable method its faster, that's why you need the
        // reference to System.Data.DataSetExtensions
        var enumerableTable = ds.Tables[0].AsEnumerable();
        // list of unique products
        var products = enumerableTable.Select(row => row.Field<string>("Product")).Distinct();
        // Add a column for each product
        foreach (string product in products)
        {
            table.Columns.Add(new DataColumn(product));
        }
        // list of unique customers
        var customerNumbers = enumerableTable.Select(row => row.Field<double>("CustomerNr")).Distinct();
        foreach (var customerNumber in customerNumbers)
        {
            DataRow record = table.NewRow();
            record["CustomerNr"] = customerNumber;
            record["Address"] = enumerableTable.First(row => row.Field<double>("CustomerNr").Equals(customerNumber))[1];
            for (int i = 2; i < table.Columns.Count; i++)
            {
                DataRow product = enumerableTable.FirstOrDefault(row => row.Field<double>("CustomerNr").Equals(customerNumber) 
                    && row.Field<string>("Product").Equals(table.Columns[i].ColumnName));
                // Quantity = 0 if product is null
                record[i] = product?["Quantity"] ?? 0;
            }
            table.Rows.Add(record);
        }
        return table;
    }
