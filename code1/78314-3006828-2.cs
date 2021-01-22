    System.Collections.Generic.List<string> Columns = DatabaseInfoCollector.GetColumnNames(textBox1.Text,cboTable.SelectedItem.ToString());
    foreach(string column in Columns)
    {
         cboColumns.Items.Add(column);
    }
