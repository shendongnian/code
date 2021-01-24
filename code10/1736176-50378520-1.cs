    Protected Sub Grid_RowCommand(sender As Object, e As GridViewCommandEventArgs)
    
        If e.CommandName = "Select" Then
            Dim LevelID As String = GridResults.DataKeys(e.CommandArgument).Item("LevelID")
            ' Do something with ID here
        End If
    
    End Sub
