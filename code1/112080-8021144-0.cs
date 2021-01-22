    	Public Function getWeb(ByRef sURL As String) As String
		Dim myWebClient As New System.Net.WebClient()
		Try
			Dim myCredentialCache As New System.Net.CredentialCache()
			Dim myURI As New Uri(sURL)
			myCredentialCache.Add(myURI, "ntlm", System.Net.CredentialCache.DefaultNetworkCredentials)
			myWebClient.Encoding = System.Text.Encoding.UTF8
			myWebClient.Credentials = myCredentialCache
			Return myWebClient.DownloadString(myURI)
		Catch ex As Exception
			Return "Exception " & ex.ToString()
		End Try
	End Function
