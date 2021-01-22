    using(Form form = new Form())
    using(DataGridView grid = new DataGridView()) {
       grid.Dock = DockStyle.Fill;
       grid.DataSource = table;
       form.Controls.Add(grid);
       form.ShowDialog(this);
    }
