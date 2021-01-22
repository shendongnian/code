    Public Class MvcApplication
        Inherits System.Web.HttpApplication
    
        Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
            routes.MapRoute("Default", "{*s}", New With {.controller = "Home", .action = "Index"})
        End Sub
    
        Sub Application_Start()
            RegisterRoutes(RouteTable.Routes)
        End Sub
    End Class
