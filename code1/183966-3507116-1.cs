    DataGridViewButtonColumn butt = new DataGridViewButtonColumn();
    butt.HeaderText = "CustomList";
    butt.Name = "CustomList";
    butt.Text = "Edit CustomList...";
    butt.UseColumnTextForButtonValue = true;
            
    dataGridView.Columns.Add(butt);
    dataGridView.CellClick += new DataGridViewCellEventHandler(dataGridView_CellClick);
