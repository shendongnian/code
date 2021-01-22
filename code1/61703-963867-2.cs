    var Items = new[] {
        new { TypeCode = 1, UserName = "Don Smith"},
        new { TypeCode = 1, UserName = "Mike Jones"},
        new { TypeCode = 1, UserName = "James Ray"},
        new { TypeCode = 2, UserName = "Tom Rizzo"},
        new { TypeCode = 2, UserName = "Alex Homes"},
        new { TypeCode = 3, UserName = "Andy Bates"}
    };
    var Columns = from i in Items
                  group i.UserName by i.TypeCode;
    Dictionary<int, List<string>> Rows = new Dictionary<int, List<string>>();
    int RowCount = Columns.Max(g => g.Count());
    for (int i = 0; i <= RowCount; i++) // Row 0 is the header row.
    {
        Rows.Add(i, new List<string>());
    }
    int RowIndex;
    foreach (IGrouping<int, string> c in Columns)
    {
        Rows[0].Add(c.Key.ToString());
        RowIndex = 1;
        foreach (string user in c)
        {
            Rows[RowIndex].Add(user);
            RowIndex++;
        }
        for (int r = RowIndex; r <= Columns.Count(); r++)
        {
            Rows[r].Add(string.Empty);
        }
    }
    foreach (List<string> row in Rows.Values)
    {
        Console.WriteLine(row.Aggregate((current, next) => current + " | " + next));
    }
    Console.ReadLine();
