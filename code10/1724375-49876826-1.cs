    for (int j = 0; j < dataGridView1.Columns.Count; j++)
    {
        pdftable.AddCell(new Phrase(dataGridView1.Rows[i].Cells[j].Value.ToString(), text));
    }
    if (i == dataGridView1.RowCount - 1)
    {
        pdfdoc.Add(pdftable);
    }
    else if (dataGridView1.Rows[i].Cells["Warehouse"].Value.ToString() != dataGridView1.Rows[i + 1].Cells["Warehouse"].Value.ToString())
    {
        pdfdoc.Add(pdftable);
        pdfdoc.NewPage();
        pdftable.DeleteBodyRows();
    }
