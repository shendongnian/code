        Dim TableLayoutPanel3 As New TableLayoutPanel()
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.Location = New System.Drawing.Point(32, 287)
        TableLayoutPanel3.AutoSize = True
        TableLayoutPanel3.Size = New System.Drawing.Size(620, 20)
        TableLayoutPanel3.ColumnCount = 3
        TableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 26.34146!))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 73.65854!))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 85.0!))
        Controls.Add(TableLayoutPanel3)        
        TableLayoutPanel3.GrowStyle = TableLayoutPanelGrowStyle.AddRows
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Absolute, 20))
        TableLayoutPanel3.SuspendLayout()
        TableLayoutPanel3.RowCount += 1
        Dim tb1 As New TextBox()
        Dim tb2 As New TextBox()
        Dim tb3 As New TextBox()
        TableLayoutPanel3.Controls.Add(tb1 , 0, TableLayoutPanel3.RowCount - 1)
        TableLayoutPanel3.Controls.Add(tb2, 1, TableLayoutPanel3.RowCount - 1)
        TableLayoutPanel3.Controls.Add(tb3, 2, TableLayoutPanel3.RowCount - 1)
        TableLayoutPanel3.ResumeLayout()
        tb1.Focus()
