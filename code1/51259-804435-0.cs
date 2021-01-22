        <Runtime.CompilerServices.Extension()> _
    Public Function PartSeek(ByVal GridView As DataGridView, ByVal ColumnName As String, ByVal Value As String, ByVal Part As Boolean) As Boolean
        Dim Located As Boolean = False
        If GridView.Columns.Contains(ColumnName) Then
            Dim SingleRow As DataGridViewRow
            If Part Then
                SingleRow = (From Rows In GridView.Rows.Cast(Of DataGridViewRow)() _
                             Where Rows.Cells(ColumnName).Value.ToString().Contains(Value)).FirstOrDefault
            Else
                SingleRow = (From Rows In GridView.Rows.Cast(Of DataGridViewRow)() _
                             Where Rows.Cells(ColumnName).Value.ToString() = Value).FirstOrDefault
            End If
            If Not IsNothing(SingleRow) Then
                If GridView.CurrentCell.RowIndex <> SingleRow.Index Then
                    GridView.CurrentCell = GridView(0, SingleRow.Index)
                End If
                DirectCast(GridView.Parent, Form).ActiveControl = GridView
                Located = True
            End If
            Return Located
        Else
            Throw New Exception("Column '" & ColumnName & "' not contained in this DataGridView")
        End If
    End Function
