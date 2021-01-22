    Public Class BaseForm
        Inherits System.Windows.Forms.Form
        Implements FormInterface
    
        Public Sub SetupForm() Implements FormInterface.SetupForm
    
        End Sub
        Public Sub DoShow() Implements FormInterface.DoSHow
            Me.Show()
        End Sub
        Public Sub DoHide() Implements FormInterface.DoHide
            Me.Hide()
        End Sub
    
    End Class
