    Public Shared Function ProductName() As String
        If Windows.Application.ResourceAssembly Is Nothing Then 
            Return Nothing
        End If
    
        Return Windows.Application.ResourceAssembly.GetName().Name
    End Sub
