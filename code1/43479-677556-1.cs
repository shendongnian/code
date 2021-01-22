    private void AddControl(Control ctl)
    {
        tableLayoutPnl.RowCount += 1;
        tableLayoutPnl.RowStyles.Add(
            new RowStyle(SizeType.Percent, 100F / tableLayoutPnl.RowCount));
        ctl.Dock = DockStyle.Fill;
        tableLayoutPnl.Controls.Add(ctl, 0, tableLayoutPnl.RowCount - 1);
        foreach (RowStyle rs in tableLayoutPnl.RowStyles)
        {
            rs.Height = 100F / tableLayoutPnl.RowCount;
        }
    }
