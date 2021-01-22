    Protected Sub gridView_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridView.Sorting
        If IsPostBack Then
            e.Cancel = True
            Dim sortDir As SortDirection = SortDirection.Ascending
            If e.SortExpression = Me.Q_SortExpression And Me.Q_SortDirection = SortDirection.Ascending Then
                sortDir = SortDirection.Descending
            End If
            RedirectMe(e.SortExpression, sortDir)
        Else
            Dim sortExpr As String = e.SortExpression + " " + IIf(e.SortDirection = SortDirection.Ascending, "ASC", "DESC")
            Dim dv As System.Data.DataView = Me.dsrcView.Select(New DataSourceSelectArguments(sortExpr))
            Me.gridView.DataSource = dv
            Me.gridView.DataBind()
        End If
    End Sub
