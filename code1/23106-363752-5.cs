     Public Class BaseWeb
    Inherits System.Web.UI.Page
    Implements IView
    Dim c As BaseController   
    Public Function GetController() As BaseController
        Return c
    End Function
    Friend WriteOnly Property Controller1() As BaseController Implements IView.Controller
        Set(ByVal value As BaseController)
            c = value
        End Set
    End Property
