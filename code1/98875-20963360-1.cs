    Private prevColumnClick As Integer 'to store previous sorted column number
    Private secondary_column_to_sort As Integer = 0 'column 0
    Private Sub lvLog_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvLog.ColumnClick
        Dim myListView As ListView = DirectCast(sender, ListView)
        Dim sort_order As System.Windows.Forms.SortOrder
        If myListView.Columns(e.Column).Tag Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            ' Get previous sort order information from columns .tag
            sort_order = DirectCast(myListView.Columns(e.Column).Tag, System.Windows.Forms.SortOrder)
        End If
        If (prevColumnClick = e.Column) Then
            If sort_order = SortOrder.Ascending Then
                sort_order = SortOrder.Descending
            Else
                sort_order = SortOrder.Ascending
            End If
        End If
        ' Initialize ColumnSorter class
        myListView.ListViewItemSorter = New ListViewColumnSorter(e.Column, sort_order, secondary_column_to_sort)
        ' Perform the sort with these new sort options.
        'myListView.Sort()
        ' Store current column sorting order
        myListView.Columns(e.Column).Tag = sort_order
        ' Store previous column number clicked 
        prevColumnClick = e.Column
    End Sub
