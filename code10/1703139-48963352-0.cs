    Dictionary<string, List<string>> some = new Dictionary<string, List<string>>
    {
        { "Key1", new List<string>
            {
                "Val1_1",
                "Val2_1",
                "Val3_1"
            }
        },
        { "Key2", new List<string>
            {
                "Val1_2",
                "Val2_2",
                "Val3_2"
            }
        }
    };
    
    DataTable dt = new DataTable();
    var keys = some.Keys;
    
    // Add all the columns from the beginning
    dt.Columns.AddRange(keys.Select(key => new DataColumn(key)).ToArray());
    // Get the rows number using the Max count of the lists (assuming the length of the lists might change, otherwise just use some.Values[0].Count)
    int rowsNumber = some.Values.Max(s => s.Count);
    
    for (int i = 0; i < rowsNumber; i++)
    {
        var row = dt.NewRow();
    
        // Set all the values depending on the keys
        foreach (var key in keys)
        {
            row[key] = some[key][i];
        }
    
        dt.Rows.Add(row);
    }
    
    dataGridView1.DataSource = dt;
