    Imports System.Web
    Imports System.Web.Services
    Imports System.Web.SessionState
    Public Class SessionHeartbeatHttpHandler
        Implements IHttpHandler
        Implements IRequiresSessionState
        ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property
        Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
            context.Session("Heartbeat") = DateTime.Now
        End Sub
    End Class
