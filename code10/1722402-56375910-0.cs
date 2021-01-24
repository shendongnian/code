    Public Class MyClientCredentials
      Inherits ClientCredentials
    Public Sub New()
    End Sub 
    ' Perform client credentials initialization.    
    Protected Sub New(ByVal other As MyClientCredentials)
        MyBase.New(other)
    End Sub
    ''' <summary>
    ''' Link to token manager
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function CreateSecurityTokenManager() As SecurityTokenManager
        ' Return your implementation of the SecurityTokenManager.
        Return New MyClientCredentialsSecurityTokenManager(Me)
    End Function
