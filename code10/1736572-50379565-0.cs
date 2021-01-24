    Imports DevExpress.XtraEditors
    Imports DevExpress.XtraGrid.Views.Grid
    Private Sub GridView1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        If e.Column.Equals(GridView1.Columns("DesiredColumn")) Then
            XtraMessageBox.Show(GridView1.GetFocusedDataRow()("DesiredColumn").ToString())
        End If
    End Sub
    Private Sub GridView1_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles GridView1.ShowingEditor
        If GridView1.FocusedColumn.Equals(GridView1.Columns("DesiredColumn")) Then
            e.Cancel = True
        End If
    End Sub
