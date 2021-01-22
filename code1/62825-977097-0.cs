    Public Class RequiresRoleAttribute : Inherits ActionFilterAttribute
        Private _role As String
        Public Property Role() As String
            Get
                Return Me._role
            End Get
            Set(ByVal value As String)
                Me._role = value
            End Set
        End Property
        Public Overrides Sub OnActionExecuting(ByVal filterContext As System.Web.Mvc.ActionExecutingContext)
            If Not String.IsNullOrEmpty(Me.Role) Then
                If Not filterContext.HttpContext.User.Identity.IsAuthenticated Then
                    Dim redirectOnSuccess As String = filterContext.HttpContext.Request.Url.AbsolutePath
                    Dim redirectUrl As String = String.Format("?ReturnUrl={0}", redirectOnSuccess)
                    Dim loginUrl As String = FormsAuthentication.LoginUrl + redirectUrl
                    filterContext.HttpContext.Response.Redirect(loginUrl, True)
                Else
                    Dim hasAccess As Boolean = filterContext.HttpContext.User.IsInRole(Me.Role)
                    If Not hasAccess Then
                        Throw New UnauthorizedAccessException("You don't have access to this page. Only " & Me.Role & " can view this page.")
                    End If
                End If
            Else
                Throw New InvalidOperationException("No Role Specified")
            End If
        End Sub
    End Class
