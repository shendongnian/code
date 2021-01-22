    Public Shared Sub CreateKeyPair(ByVal filename As String)
        Dim xmlpublic As String = String.Empty
        Dim xmlprivate As String = String.Empty
        CreateKeyPair(xmlpublic, xmlprivate)
        Try
            Dim writer As New StreamWriter(filename + ".prv")
            writer.Write(xmlprivate)
            writer.Flush()
            writer.Close()
        Catch ex As Exception
            Throw New CryptographicException("Unable to write private key file: " + ex.Message)
        End Try
        Try
            Dim writer = New StreamWriter(filename + ".pub")
            writer.Write(xmlpublic)
            writer.Flush()
            writer.Close()
        Catch ex As Exception
            Throw New CryptographicException("Unable to write public key file: " + ex.Message)
        End Try
    End Sub
    Public Shared Sub CreateKeyPair(ByRef xmlpublic As String, ByRef xmlprivate As String)
        Dim rsa As RSA = Nothing
        Try
            rsa.Create()
        Catch ex As Exception
            Throw New CryptographicException("Unable to initialize keys: " + ex.Message)
        End Try
        Try
            xmlpublic = rsa.ToXmlString(True)
        Catch ex As Exception
            Throw New CryptographicException("Unable to generate public key: " + ex.Message)
        End Try
        Try
            xmlprivate = rsa.ToXmlString(False)
        Catch ex As Exception
            Throw New CryptographicException("Unable to generate private key: " + ex.Message)
        End Try
    End Sub
