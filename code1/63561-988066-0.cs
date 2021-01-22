    Protected Overrides Sub RenderAttributes(ByVal writer as HtmlTextWriter)
        If Not String.IsNullOrEmpty(Me.Href) Then
            MyBase.Attributes.Item("href") = MyBase.ResolveClientUrl(Me.Href)
        End If
        MyBase.RenderAttributes(writer)
    End Sub
