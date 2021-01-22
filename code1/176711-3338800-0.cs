    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim dt As New Data.DataTable
        dt.Columns.Add("Row No", GetType(Int32))
        dt.Columns.Add("Age", GetType(String))
        dt.Columns.Add("Annual Sales", GetType(String))
        dt.Columns.Add("Assortment", GetType(String))
    
        dt.Rows.Add(1, "High", "High", "CORE")
        dt.Rows.Add(5, "High", "Low", "CORE")
        dt.Rows.Add(9, "High", "Medium", "CORE")
    
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub
    
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType <> DataControlRowType.DataRow Then
            Exit Sub
        End If
    
        Dim dr = DirectCast(e.Row.DataItem, Data.DataRowView).Row
    
        Select Case DirectCast(dr("Annual Sales"), String)
            Case "High"
                e.Row.BackColor = Drawing.Color.Gray
            Case "Low"
                e.Row.BackColor = Drawing.Color.White
            Case "Medium"
                e.Row.BackColor = Drawing.Color.Gray
        End Select
    End Sub
