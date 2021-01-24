    for (int i = 1; i < dataGridView1.Rows.Count; i++)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("|"); // frame left border
        for (int j = 1; j < dataGridView1.Columns.Count; j++)
        {
            // try to get the value            
            string value = dataGridView1.Rows[i].Cells[j].Value?.ToString();
            // if there is no value => take a space otherwise take the value
            value = string.IsNullOrEmpty(value) ? " " : value;
            // plug it into your string builder
            sb.Append(value);
        }
        sb.Append("|");  // frame right border
        // lunge the finished string into the array
        map[i] = sb.ToString();
    }
    // close the frame
    map[dataGridView1.Rows.Count] = "+" + new string('-', dataGridView1.Columns.Count - 1) + "+";
    Console.WriteLine(string.Join(Environment.NewLine, map));
