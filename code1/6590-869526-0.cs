    Public MustInherit Class Singleton(Of T As {Class, New})
        Public Sub New()
        End Sub
    
        Private Class SingletonCreator
            Shared Sub New()
            End Sub
            Friend Shared ReadOnly Instance As New T
        End Class
    
        Public Shared ReadOnly Property Instance() As T
            Get
                Return SingletonCreator.Instance
            End Get
        End Property
    End Class
