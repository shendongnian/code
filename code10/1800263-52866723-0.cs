    DataTable dt = new DataTable();
    using (FileStream stream = File.OpenRead("logs.txt"))
    {
        using (StreamReader reader = new StreamReader(stream))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] items = line.Split(',');
    
                // Check if the number of items in the line is 
                // greater than the current number of columns in the datatable.
                if(items.Length > dt.Columns.Count)
                {
                    // Add new columns to the datatable.
                    for (int i = dt.Columns.Count; i < items.Length; i++)
                    {
                        dt.Columns.Add("Column " + i);
                    }
                }
                // Create new row
                var newRow = dt.NewRow();
                // Loop thru the items and add them to the row one by one.
                for (var j = 0; j < items.Length; j++)
                {
                    newRow[j] = items[j];
                }
    
                //Add row to the datatable.
                dt.Rows.Add(newRow);
                line = reader.ReadLine();
            }
            // Bind datatable to the gridview.
            dataGridView1.DataSource = dt;
        }
    }
