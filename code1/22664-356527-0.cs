    Public Overrides ReadOnly Property DisplayName() As String
             Get
                Dim BaseValue As String = MyBase.DisplayName
                Dim Translated As String = Some.ResourceManager.GetString(BaseValue)
                If String.IsNullOrEmpty(Translated) Then
                   Return MyBase.DisplayName
                Else
                   Return Translated
               End If
        End Get
    End Property
