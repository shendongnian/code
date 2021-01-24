        // C#
        /.../
        var dt = new System.Data.DataTable();
    
            foreach (string path in listBox.Items) // file(paths) are stored in a ListBox
            {
                Evaluation eval = new Evaluation(path); // create Evaluation for that file
    
                eval.Calculate(); // does calculations and stores results inside the native C++ vectors/doubles
                Dictionary<string, object> dict = eval.GetParameters(); // retrieve the parameters from native C++ as a Dictionary
    
                if (table.Columns.Count < 1)  // only add columns when DataTable is empty
                {
                    foreach (var c in dict.Keys)
                        table.Columns.Add(new DataColumn(c)); // add new column for each parameter string
                }
    
                DataRow row = table.NewRow();  // create new row for each file
                int i = 0;
    
                foreach (var value in dict.Values)
                {
                    row[i] = value; // inserts values column by column
                    i++;
                }
                table.Rows.Add(row); // add the populated row to the DataTable
            }
        dataGridView1.DataSource = table; // bind DataTable as a DataSource
        /.../
