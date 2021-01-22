    Public ParentDelegateEvent As System.Delegate
    Public Sub btnDelegateClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelegate.Click
        Dim args(1) As Object
        args(0) = sender
        args(1) = e
        ParentDelegateEvent.DynamicInvoke(args)
    End Sub
