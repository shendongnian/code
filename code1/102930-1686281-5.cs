      Public Class BaseForm
        Inherits System.Windows.Forms.Form
        Implements FormInterface
    
        Public Sub SetupForm() Implements FormInterface.SetupForm
    
        End Sub
        Public Sub Show() Implements FormInterface.SHow
            Me.Show()
        End Sub
        Public Sub Hide() Implements FormInterface.Hide
            Me.Hide()
        End Sub
    
    End Class
