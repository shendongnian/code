    TabControl tabControl = new TabControl();
    tabControl.Dock = DockStyle.Fill;
    foreach (Char c in lastNameList)
    {
        TabPage tabPage = new TabPage();
        tabPage.Text = c.ToString();
        DataGrid grid = new DataGrid();
        grid.Dock = DockStyle.Fill;
        grid.DataSource = dataForTheCurrentLoop;
        tabPage.Controls.Add(grid);
        tabControl.Controls.Add(tabPage);
    }
    this.Controls.Add(tabControl);
