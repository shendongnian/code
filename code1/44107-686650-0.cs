    Public Class RedirectToHttpsModule
        Implements IHttpModule
    
        Public Sub Dispose() Implements IHttpModule.Dispose
        End Sub
    
        Public Sub Init(ByVal context As HttpApplication) Implements IHttpModule.Init
            AddHandler context.BeginRequest, AddressOf context_BeginRequest
        End Sub
    
        Private Sub context_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
            Dim application As HttpApplication = TryCast(sender, HttpApplication)
            If Not application.Request.IsSecureConnection And Not application.Request.IsLocal Then
                 application.Response.Redirect(application.Request.Url.ToString().Replace(application.Request.Url.Scheme, "https"))
            End If
        End Sub
    
    End Class
