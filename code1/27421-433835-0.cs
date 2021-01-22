    [STAThread]
    static void Main() {
        Application.EnableVisualStyles();
        Form form = new Form();
        TableLayoutPanel layout = new TableLayoutPanel();
        layout.Dock = DockStyle.Fill;
        form.Controls.Add(layout);
        layout.ColumnCount = 3;
        layout.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
        for (int i = 0; i < 200; i++)
        {
            CheckBox chk = new CheckBox();
            chk.Text = "item " + i;
            layout.Controls.Add(chk);
        }
        Application.Run(form);
    }
