    Public Class DataGridView
        Inherits System.Windows.Forms.DataGridView
    
        Protected Overrides Sub OnSelectionChanged(ByVal e As System.EventArgs)
            Static fIsEventDisabled As Boolean
    
            If fIsEventDisabled = False Then
    
                If Me.SelectedCells.Count > 1 Then
                    Dim iColumnIndex As Integer = Me.SelectedCells(0).ColumnIndex
                    fIsEventDisabled = True
                    ClearSelection()
                    SelectColumn(iColumnIndex) 'not calling SetSelectedColumnCore on purpose
                    fIsEventDisabled = False
                End If
    
            End If
    
            MyBase.OnSelectionChanged(e)
    
        End Sub
    
        Public Sub SelectColumn(ByVal index As Integer)
            For Each oRow As DataGridViewRow In Me.Rows
                If oRow.IsNewRow = False Then
                    oRow.Cells.Item(index).Selected = True
                End If
            Next
        End Sub
    
    End Class
