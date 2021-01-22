    Inherits System.Windows.Forms.Form
    Implements IView
    Dim c As BaseController
    Public Function GetController() As BaseController
        Return c
    End Function
    Friend WriteOnly Property Controller() As BaseController Implements IView.Controller
        Set(ByVal value As BaseController)
            c = value
        End Set
    End Property
