        Public ReadOnly Property OutlookSession() As Outlook.NameSpace
            Get
                If Not OutlookApplication Is Nothing Then
                    Return OutlookApplication.GetNamespace ("MAPI")
                Else
                    Return Nothing
                End If
            End Get
        End Property
