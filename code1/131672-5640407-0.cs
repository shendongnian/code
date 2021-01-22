    #Region "Non-greyed read only support"
    Private isReadOnly As Boolean
    Public Property [ReadOnly]() As Boolean
        Get
            Return Me.isReadOnly
        End Get
        Set(ByVal value As Boolean)
            Me.isReadOnly = value
        End Set
    End Property
    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        If Me.isReadOnly Then Return True
        Return MyBase.ProcessDialogKey(keyData)
    End Function
    Public Function PreFilterMessage(ByRef m As Message) As Boolean
        If m.Msg = &H204 Then 'WM_RBUTTONDOWN
            If Me.isReadOnly Then Return True
        End If
        Return False
    End Function
