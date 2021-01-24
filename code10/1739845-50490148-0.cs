    Friend Overridable Property Button1 As Button
        <CompilerGenerated> _
        Get
            Return Me._Button1
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal WithEventsValue As Button)
            Dim handler As EventHandler = New EventHandler(AddressOf Me.Button1_Click)
            Dim button As Button = Me._Button1
            If (Not button Is Nothing) Then
                RemoveHandler button.Click, handler
            End If
            Me._Button1 = WithEventsValue
            button = Me._Button1
            If (Not button Is Nothing) Then
                AddHandler button.Click, handler
            End If
        End Set
    End Property
