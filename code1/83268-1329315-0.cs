    Sub Page_Load()
       If Not Page.IsPostBack Then
          If Request.QueryString("AcceptsCookies") Is Nothing Then
               Response.Cookies("TestCookie").Value = "ok"
               Response.Cookies("TestCookie").Expires = _
                  DateTime.Now.AddMinutes(1)
               Response.Redirect("TestForCookies.aspx?redirect=" & _
                  Server.UrlEncode(Request.Url.ToString))
          Else
               labelAcceptsCookies.Text = "Accept cookies = " & _
                  Request.QueryString("AcceptsCookies")
          End If
       End If
    End Sub
