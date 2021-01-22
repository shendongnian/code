    Private Sub myDvGrid_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles myDvGrid.EditingControlShowing
        Dim c As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
        RemoveHandler c.PreviewKeyDown, AddressOf edtctrlOn_PreviewKeyDown
        RemoveHandler c.TextChanged, AddressOf edtctrlOn_TextChanged
        AddHandler c.TextChanged, AddressOf edtctrlOn_TextChanged
        AddHandler c.PreviewKeyDown, AddressOf edtctrlOn_PreviewKeyDown
           
    End Sub
