    for (int j = 0; j < dataGridView1.Columns.Count; j++)
    {
        if (dataGridView1.Rows[i].Cells["Warehouse"].Value.ToString() == dataGridView1.Rows[i + 1].Cells["Warehouse"].Value.ToString())
        {
            pdftable.AddCell(new Phrase(dataGridView1.Rows[i].Cells[j].Value.ToString(), text));
        }
        else
        {
            pdftable.AddCell(new Phrase(dataGridView1.Rows[i].Cells[j].Value.ToString(), text));
            pdfdoc.Add(pdftable);
            pdfdoc.NewPage();
            pdftable.DeleteBodyRows();
        }
    }
