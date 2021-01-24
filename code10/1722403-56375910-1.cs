    Public Class MyClientCredentialsSecurityTokenManager
      Inherits ClientCredentialsSecurityTokenManager
    Private _oCredenciales As MyClientCredentials
    Public Sub New(ByVal credentials As MyClientCredentials)
        MyBase.New(credentials)
        Me._oCredenciales = credentials
    End Sub
    ''' <summary>
    ''' Custom token for each operation
    ''' </summary>
    ''' <param name="p_oRequirement"></param>
    ''' <returns></returns>
    Public Overrides Function CreateSecurityTokenProvider(ByVal p_oRequirement As SecurityTokenRequirement) As SecurityTokenProvider
        Dim oRes As SecurityTokenProvider = Nothing
        If p_oRequirement.TokenType = SecurityTokenTypes.X509Certificate Then
            Dim direction = p_oRequirement.GetProperty(Of MessageDirection)(ServiceModelSecurityTokenRequirement.MessageDirectionProperty)
            If direction = MessageDirection.Output Then
                If p_oRequirement.KeyUsage = SecurityKeyUsage.Signature Then
                    oRes = New X509SecurityTokenProvider(Me._oCredenciales.ClientCertificate.Certificate)
                Else
                    oRes = New X509SecurityTokenProvider(Me._oCredenciales.ServiceCertificate.DefaultCertificate())
                End If
            End If
        Else
            oRes = MyBase.CreateSecurityTokenProvider(p_oRequirement)
        End If
        Return oRes
    End Function
