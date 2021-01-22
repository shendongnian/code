    Public MustInherit Class ApplicationController
        Inherits System.Web.Mvc.Controller
    
        Sub New()
            ViewData("SideMenu") = getSideMenu()
        End Sub
    
    End Class
