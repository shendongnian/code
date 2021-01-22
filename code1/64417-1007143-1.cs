     Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
    Dim btnsave As New ImageButton
    If e.Row.RowType <> DataControlRowType.Pager And e.Row.RowType <>  DataControlRowType.Header Then
        AddHandler btnedit.Click, AddressOf btnedit_Click
        GridView1.Rows(i).Cells(8).Controls.Add(btndel)
    end if
    end sub
    Public Delegate Sub ImageClickEventHandler(ByVal sender As Object, ByVal e As ImageClickEventArgs)
    Sub btnedit_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
    //do whatever you want here.
    //possibly a redirect to the current page so nothing else fires
    end sub
