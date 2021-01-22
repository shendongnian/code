    Inherits BaseController
    Dim model As M
    Dim view As V
    Public Sub New()
        model = New M
        view.Controller = Me
        model.Controller = Me
    End Sub
    Public Overridable Function GetModel() As M
        Return model
    End Function
    Public Overridable Function GetView() As V
        Return view
    End Function  
