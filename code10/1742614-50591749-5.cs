    if (!string.IsNullOrEmpty(enteredText))
    {
        var rows = dataGridView1.Rows
            .Cast<DataGridViewRow>()
            .Where(r => ((string)r.Cells["Column1"].Value).Contains(enteredText));
        foreach (var row in rows)
        {
            row.Selected = true;
        }
    }
    
