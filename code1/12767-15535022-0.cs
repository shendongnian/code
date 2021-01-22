    Private Sub SetPageSize(ByVal pageSize As Integer)
        ' Set cookie value to pageSize
        Dim pageSizeCookie As HttpCookie = New HttpCookie(pageSizeCookieName)
        With pageSizeCookie
            .Expires = Now.AddYears(100)
            .Value = pageSize.ToString
        End With
        ' Add to response to save it
        Me.Response.Cookies.Add(pageSizeCookie)
        ' Add to request so available for postback
        Me.Request.Cookies.Remove(pageSizeCookieName)
        Me.Request.Cookies.Add(pageSizeCookie)
    End Sub
