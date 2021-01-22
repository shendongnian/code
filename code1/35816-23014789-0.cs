    public static class Test
    {
        public static void Main()
        {
            var dataTable = new System.Data.DataTable(Guid.NewGuid().ToString());
    
            var columnCode = new DataColumn("Code");
            var columnLength = new DataColumn("Length");
            var columnProduct = new DataColumn("Product");
    
            dataTable.Columns.AddRange(new DataColumn[]
                {
                    columnCode,
                    columnLength,
                    columnProduct
                });
    
            var item = new List<SomeClass>();
    
            item.Select(data => new
            {
                data.Id,
                data.Name,
                data.SomeValue
            }).AddToDataTable(dataTable);
        }
    }
    
    static class Extensions
    {
        public static void AddToDataTable<T>(this IEnumerable<T> enumerable, System.Data.DataTable table)
        {
            if (enumerable.FirstOrDefault() == null)
            {
                table.Rows.Add(new[] {string.Empty});
                return;
            }
    
            var properties = enumerable.FirstOrDefault().GetType().GetProperties();
    
            foreach (var item in enumerable)
            {
                var row = table.NewRow();
                foreach (var property in properties)
                {
                    row[property.Name] = item.GetType().InvokeMember(property.Name, BindingFlags.GetProperty, null, item, null);
                }
                table.Rows.Add(row);
            }
        }
    }
