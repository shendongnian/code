    Public Sub AutoSizeColumns()
        Dim gv As GridView = TryCast(Me.listview1.View, GridView)
        If gv IsNot Nothing Then
            For Each c As GridViewColumn In gv.Columns
                If Double.IsNaN(c.Width) Then
                    c.Width = c.ActualWidth
                End If
                c.Width = Double.NaN
            Next
        End If
    End Sub
