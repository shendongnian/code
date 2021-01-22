    Public Property BerichtAsByte As Byte()
            Get
                If Me.Bericht Is Nothing Then Return Nothing
                Return Me.Bericht.ToArray
            End Get
            Set(value As Byte())
                If value Is Nothing Then
                    Me.Bericht = Nothing
                Else
                    Me.Bericht = New Data.Linq.Binary(value)
                End If
            End Set
        End Property
