    if (!string.IsNullOrEmpty(enteredText))
    {
        var row = dataGridView1.Rows
            .Cast<DataGridViewRow>()
            .FirstOrDefault(r => ((string)r.Cells["Column1"].Value).Contains(enteredText));
        if (row != null)
        {
            row.Selected = true;
        }
    }
