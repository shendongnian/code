    Protected Overrides Sub Paint(graphics As System.Drawing.Graphics, clipBounds As System.Drawing.Rectangle, cellBounds As System.Drawing.Rectangle, rowIndex As Integer, dataGridViewElementState As System.Windows.Forms.DataGridViewElementStates, value As Object, formattedValue As Object, errorText As String, cellStyle As System.Windows.Forms.DataGridViewCellStyle, advancedBorderStyle As System.Windows.Forms.DataGridViewAdvancedBorderStyle, paintParts As System.Windows.Forms.DataGridViewPaintParts)
        If Not Me.OwningRow.DataBoundItem Is Nothing Then
            If TypeOf Me.OwningRow.DataBoundItem Is DataRowView Then
            End If
        End If
