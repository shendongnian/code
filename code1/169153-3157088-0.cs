    Public NotInheritable Class Helper
       Private Sub New()
       End Sub
    
       Public Shared Function getAppSetting(ByVal key As String) As String
           Dim returnValue As Object = My.Settings(key)
           If returnValue Is Nothing Then
               Return String.Empty
           Else
               Return returnValue.ToString
           End If
       End Function
    End Class
