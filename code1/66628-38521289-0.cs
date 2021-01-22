    DataTable table = new DataTable
    {
        Columns = {
            "Name", // typeof(string) is implied
            {"Marks", typeof(int)}
        },
        TableName = "MarksTable" //optional
    };
    table.Rows.Add("ravi", 500);
