    var products = new DataTable();
    products.Columns.Add("ProductId", typeof(string));
    products.Columns.Add("Name", typeof(string));
    products.Columns.Add("Price", typeof(int));
    
    int j = 0;
    for (int i = 0; i < 30; i++)
    {
    	j++;
    	products.Rows.Add(new object[] { i + 1, $"Prod{i:00}", i/10 + 1 });
    	if (i % 10 == 9) j = 0;
    }
    
    var result = products.AsEnumerable().GroupBy(r => r.Field<int>("Price"))
    	.OrderByDescending(g => g.Key)
    	.Take(1);
