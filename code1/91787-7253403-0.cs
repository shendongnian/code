    Private _thePassWordBox As PasswordBox
	Public ReadOnly Property ThePassWordBox As PasswordBox
        Get
            If IsNothing(_thePassWordBox) Then _thePassWordBox = New PasswordBox
            Return _thePassWordBox
        End Get
    End Property
