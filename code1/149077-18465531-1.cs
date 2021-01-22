    Protected Sub gvTopXByContest_OnSorting(sender As Object, e As GridViewSortEventArgs)
            
        If e.SortExpression <> DirectCast(sender, GridView).SortExpression Then
            If e.SortExpression = "txtOnlineUserName" Then
                Response.Redirect(URL to redirect to goes here)
            ElseIf e.SortExpression = "fltTotalPoints" Then
                Response.Redirect(URL to redirect to goes here)
            Else
                'I could have used another ElseIf here but since there are only 3 columns Else works
                Response.Redirect(URL to redirect to goes here)
            End If
    
    End Sub
