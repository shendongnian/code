    Private m_CurUser As String
    Public ReadOnly Property CurrentUser As String
		Get
			If String.IsNullOrEmpty(m_CurUser) Then
				Dim who As System.Security.Principal.IIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
				If who Is Nothing Then
					m_CurUser = Environment.UserDomainName & "\" & Environment.UserName
				Else
					m_CurUser = who.Name
				End If
			End If
			Return m_CurUser
		End Get
	End Property
