    if (enteredText != String.Empty)
    {
        var rows = dataGridView1.Rows
            .Cast<DataGridViewRow>()
            .Where(r => r.Cells["Column1"].Value.ToString().Contains(enteredText));
        foreach (var row in rows)
        {
            row.Selected = true;
        }
    }
    
