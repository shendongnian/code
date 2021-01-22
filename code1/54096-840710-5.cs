    Class C2
        Private _ev As EventThrower
        Public Property ev() As EventThrower
            Get
                Return _ev
            End Get
            Set(ByVal value As EventThrower)
                If _ev IsNot Nothing Then
                        removehandler _ev.event, addressof catch
                End If
                _ev = value
                If _ev IsNot Nothing Then
                        addhandler _ev.event, addressof catch
                End If
            End Set
        End Property
        Public Sub New()
            ev = New EventThrower()
        End Sub
        Public Sub catcher()
            Debug.print("Event")
        End Sub
    End Class
