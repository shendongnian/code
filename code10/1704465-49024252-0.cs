    DataTable table = new DataTable();
    table.Columns.Add("Status", typeof(string));
    table.Columns.Add("Filename", typeof(string));
    table.Rows.Add("Valid", "C:\\Test File With Spaces.txt");
    table.Rows.Add("Valid", "C:\\Test File.txt");
    table.Rows.Add("Invalid", "C:\\Test File With Spaces.txt");
    table.Rows.Add("Valid", "C:\\Test.txt");
    string filename = "C:\\Test File With Spaces.txt";
    var allRows = table.Select(); // Expected Rows: 4 Actual Rows: 4
    var filteredRows = table.Select("Status = 'Valid'"); // Expected Rows: 3 Actual Rows: 3
    var filteredRows2 = table.Select($"Status = 'Valid' AND Filename = '{filename}'"); // Expected Rows: 1 Actual Rows: 1
