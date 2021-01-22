     Protected Sub grdHist_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdHist.RowDataBound
           
          Dim col1 As String = HttpUtility.HtmlDecode(e.Row.Cells(2).Text)
    
          e.Row.Cells(2).Text = col1
    
    End Sub
