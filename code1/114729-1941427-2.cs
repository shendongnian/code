    private void exportDGVToCSV(string filename)
    {
        if (dataGridView1.Columns.Count != 0) 
        {    
            using (Stream stream = File.OpenWrite(filename))
            {
                stream.SetLength(0);
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    // loop through each row of our DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows) 
                    {
                        string line = string.Join(",", row.Cells.Select(x => $"{x}"));
                        writer.WriteLine(line);
                    }
                    writer.Flush();
                }
            };
        }
    }
