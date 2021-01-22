    [STAThread]
    static void Main() {
        Application.EnableVisualStyles();
        Form form = new Form();
        TableLayoutPanel layout = new TableLayoutPanel();
        layout.Dock = DockStyle.Fill;
        form.Controls.Add(layout);
        layout.AutoScroll = true;
        layout.ColumnCount = 3;
        // size the columns (choice just to show options, not to be pretty)
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));    
        layout.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
        for (int i = 0; i < 200; i++)
        {
            CheckBox chk = new CheckBox();
            chk.Text = "item " + i;
            layout.Controls.Add(chk);
        }
        Application.Run(form);
    }
