    Protected Overrides Function CreateRowsInstance() As System.Windows.Forms.DataGridViewRowCollection
        Dim dgvRowCollec As DataGridViewRowCollection = MyBase.CreateRowsInstance()
        AddHandler dgvRowCollec.CollectionChanged, AddressOf dvgRCChanged
        Return dgvRowCollec
    End Function
    Private Sub dvgRCChanged(sender As Object, e As System.ComponentModel.CollectionChangeEventArgs)
        If e.Action = System.ComponentModel.CollectionChangeAction.Add Then
            Dim dgvRow As DataGridViewRow = e.Element
            dgvRow.DefaultHeaderCellType = GetType(DataGridViewRowHeaderCellEx)
        End If
    End Sub
