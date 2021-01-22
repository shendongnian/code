    public Product CreateProduct()
    {
        var p = new Product();
        p.Columns.Add(new ProductColumn {
            Name = "Name", ColumnType = 1
        });
        p.Columns.Add(new ProductColumn {
            Name = "Producer", ColumnType = 2
        });
        return p;
    }
