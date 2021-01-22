    ''' <summary>
    ''' Makes all columns in a DataGridView autosize based on displayed cells,
    ''' while leaving the column widths user-adjustable.
    ''' </summary>
    ''' <param name="dgv">A DataGridView to adjust</param>
    Friend Sub MakeAdjustableAutoSizedGridCols(ByRef dgv As DataGridView)
    	Dim width As Integer
    
    	For Each col As DataGridViewColumn In dgv.Columns
    		col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    		width = col.Width
    		col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
    		col.Width = width
    	Next
    	dgv.AllowUserToResizeColumns = True
    End Sub
