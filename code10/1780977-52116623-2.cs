    var table = new DataTable();
    table.Columns.Add("day", typeof(int));
    table.Columns.Add("sales", typeof(int));
    
    //Add data
    table.Rows.Add(new []{1, 200});
    table.Rows.Add(new []{2, 200});
    //More code
    Command.Parameters.AddWithValue("@DayList", table);
