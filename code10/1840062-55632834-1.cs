    Partial Class MasterPage
        Inherits System.Web.UI.MasterPage
    
        Private Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
        Private Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
        Private _antiXsrfTokenValue As String
    
        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
            Dim requestCookie = Request.Cookies(AntiXsrfTokenKey)
            Dim requestCookieGuidValue As Guid
    
            If requestCookie IsNot Nothing AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue) Then
                _antiXsrfTokenValue = requestCookie.Value
                Page.ViewStateUserKey = _antiXsrfTokenValue
            Else
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
                Page.ViewStateUserKey = _antiXsrfTokenValue
                Dim responseCookie = New HttpCookie(AntiXsrfTokenKey) With {
                    .HttpOnly = True,
                    .Value = _antiXsrfTokenValue
                }
    
                If FormsAuthentication.RequireSSL AndAlso Request.IsSecureConnection Then
                    responseCookie.Secure = True
                End If
    
                Response.Cookies.[Set](responseCookie)
            End If
    
            AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
        End Sub
    
        Protected Sub master_Page_PreLoad(ByVal sender As Object, ByVal e As EventArgs)
            If Not IsPostBack Then
                ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
                ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, String.Empty)
            Else
    
                If CStr(ViewState(AntiXsrfTokenKey)) <> _antiXsrfTokenValue OrElse CStr(ViewState(AntiXsrfUserNameKey)) <> (If(Context.User.Identity.Name, String.Empty)) Then
                    Throw New InvalidOperationException("Validation of Anti-XSRF token failed.")
                End If
            End If
        End Sub
    
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
    End Class
