    static List<DataTableData> GetDataTableData()
    {
        var data = new List<DataTableData>
        {
            new DataTableData() { Id = "23456", ParentID = "12345", Name = "Middle" },
            new DataTableData() { Id = "55555", ParentID = "12345", Name = "Middle" },
            new DataTableData() { Id = "34567", ParentID = "23456", Name = "Bottom" },
            new DataTableData() { Id = "12345", ParentID = string.Empty, Name = "Top" },
            new DataTableData() { Id = "45678", ParentID = "23456", Name = "Bottom" },
            new DataTableData() { Id = "66666", ParentID = "55555", Name = "Bottom" }
        };
        return data;
    }
