    Public Sub RadGrid_NeedDataSource(ByVal source As RadGrid, ByVal e As GridNeedDataSourceEventArgs) 'Handles RadGrid.NeedDataSource
        Dim RadGrid As RadGrid = CType(source, RadGrid)
        'Dim nestedItem As GridNestedViewItem = CType(source.NamingContainer, GridNestedViewItem)
        'Dim CustomerID = CType(nestedItem.ParentItem, GridDataItem).GetDataKeyValue(source.Attributes("TableID"))
        Dim gridSortString As String = RadGrid.MasterTableView.SortExpressions.GetSortString()
        Dim args As New DataSourceSelectArguments(gridSortString)
        If gridSortString Is Nothing Then
            RadGrid.DataSource = GetDataTable("SELECT * FROM [" + source.Attributes("TableName") + "] ") 'Where CustomerID = N'" + CustomerID + "'
        Else
            RadGrid.DataSource = GetDataTable("SELECT * FROM [" + source.Attributes("TableName") + "] ORDER BY " & gridSortString) 'Where CustomerID = N'" + CustomerID + "'
        End If
    End Sub
