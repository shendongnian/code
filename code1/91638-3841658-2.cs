    Public Class Pair(Of T1, T2)
        Public Property First As T1
        Public Property Second As T2
    
        Public Sub New(ByVal f As T1, ByVal s As T2)
            First = f
            Second = s
        End Sub
    End Class
