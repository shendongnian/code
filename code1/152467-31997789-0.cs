    ToolStrip ts = new ToolStrip();
    ToolStripComboBox comboBox = new TooLStripComboBox();
    comboBox.Dock = DockStyle.Fill;
    ts.LayoutStyle = ToolStripLayoutStyle.Table;
    ((TableLayoutSettings)ts.LayoutSettings).ColumnCount = 1;
    ((TableLayoutSettings)ts.LayoutSettings).RowCount = 1;
    ((TableLayoutSettings)ts.LayoutSettings).SetColumnSpan(comboBox,1);
    ts.Items.Add(comboBox);
