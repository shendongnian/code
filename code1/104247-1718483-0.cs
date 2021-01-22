    private int currentMouseOverRow = 0;
    private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            ContextMenu m = new ContextMenu();
            m.MenuItems.Add(new MenuItem("Cut"));
            m.MenuItems.Add(new MenuItem("Copy"));
            m.MenuItems.Add(new MenuItem("Paste"));
            if (currentMouseOverRow >= 0)
            {
                m.MenuItems.Add(new MenuItem(string.Format("Do some to row {0}", currentMouseOverRow.ToString())));
            }
                
            m.Show(dataGridView1, new Point(e.X, e.Y));
        }
    }
    private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
        currentMouseOverRow = e.RowIndex;
    }
    private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
    {
        currentMouseOverRow = -1;
    }
