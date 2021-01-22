    Protected Sub RadGrid1_ItemCreated(ByVal sender As Object, ByVal e As GridItemEventArgs)
        If TypeOf e.Item Is GridCommandItem Then
            Dim myButton As LinkButton = TryCast(e.Item.FindControl("myButtonID"), LinkButton)
            myButton.Focus()
        End If
    End Sub
