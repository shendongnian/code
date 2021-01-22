    Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim key As Keys = (keyData And Keys.KeyCode)
        If key = Keys.Enter Then
            If MyBase.CurrentCell.ColumnIndex = 1 Then
                Dim iRow As Integer = MyBase.CurrentCell.RowIndex
                MyBase.EndEdit()
                Try
                    MyBase.CurrentCell = Nothing
                    MyBase.CurrentCell = MyBase.Rows(iRow).Cells(1)
                    frmFilter.cmdOk_Click(Me, New EventArgs)
                Catch ex As Exception
                End Try
                Return True
            End If
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function
