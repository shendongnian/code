    Public Shared Function GridViewRowToDataRow(ByVal gvr As GridViewRow) As DataRow
        Dim di As Object = Nothing
        Dim drv As DataRowView = Nothing
        Dim dr As DataRow = Nothing
        If gvr IsNot Nothing Then
            di = TryCast(gvr.DataItem, System.Object)
            If di IsNot Nothing Then
                drv = TryCast(di, System.Data.DataRowView)
                If drv IsNot Nothing Then
                    dr = TryCast(drv.Row, System.Data.DataRow)
                End If
            End If
        End If
        Return dr
    End Function
    Public Shared Function GridViewRowEventArgsToDataRow(ByVal e As GridViewRowEventArgs) As DataRow
        Dim gvr As GridViewRow = Nothing
        Dim di As Object = Nothing
        Dim drv As DataRowView = Nothing
        Dim dr As DataRow = Nothing
        If e.Row.RowType = DataControlRowType.DataRow Then
            gvr = TryCast(e.Row, System.Web.UI.WebControls.GridViewRow)
            dr = Helpers.GridViewRowToDataRow(gvr)
        End If
        Return dr
    End Function
