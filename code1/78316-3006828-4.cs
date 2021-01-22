    System.Collections.Generic.List<string> Tables = DatabaseInfoCollector.GetTables(textBox1.Text);
    foreach(string table in Tables)
    {
         cboTable.Items.Add(table);
    }
