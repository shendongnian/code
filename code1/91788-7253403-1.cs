	Public ReadOnly Property PassWord As String
        Get
            Return If((PasswordAccessor Is Nothing), String.Empty, PasswordAccessor.Invoke())
        End Get
    End Property
	
