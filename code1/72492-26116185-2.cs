         Private Sub btnAddRow_Click(sender As System.Object, e As System.EventArgs) Handles btnAddRow.Click
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
     End Sub
