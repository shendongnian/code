    Private _endEditing As Boolean = False
    Private Sub DataGrid_GotFocus(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Me._endEditing Then
            Me._endEditing = False
            Return
        End If
        Dim cell = TryCast(e.OriginalSource, DataGridCell)
        If cell Is Nothing Then
            Return
        End If
        If cell.IsReadOnly Then
            Return
        End If
        DirectCast(sender, DataGrid).BeginEdit(e)
        .
        .
        .
