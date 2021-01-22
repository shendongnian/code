    Public Class SomeClass
    
        <Obsolete("Constructor intended for design mode only", True)>
        Public Sub New()
            DesignMode = True
            If DesignMode Then
                Name = "Paula is Brillant"
            End If
        End Sub
    
        Public Property DesignMode As Boolean
        Public Property Name As String = "FileNotFound"
    End Class
