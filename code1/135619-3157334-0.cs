        #Region "Imports"
    Imports System.Text
    Imports System.Security.Cryptography
    #End Region
    
    Public NotInheritable Class SharedOAuth
    
    #Region "Class Declarations"
        Private Const unreservedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~"
    
        Private Const OAuthVersion As String = "1.0"
        Private Const OAuthParameterPrefix As String = "oauth_"
        Private Const OAuthParameterExclusionPrefix As String = "xoauth_"
    
        Private Const OAuthConsumerKeyKey As String = "oauth_consumer_key"
        Private Const OAuthCallbackKey As String = "oauth_callback"
        Private Const OAuthVersionKey As String = "oauth_version"
        Private Const OAuthSignatureMethodKey As String = "oauth_signature_method"
        Private Const OAuthSignatureKey As String = "oauth_signature"
        Private Const OAuthTimestampKey As String = "oauth_timestamp"
        Private Const OAuthNonceKey As String = "oauth_nonce"
        Private Const OAuthTokenKey As String = "oauth_token"
        Private Const OAuthTokenSecretKey As String = "oauth_token_secret"
    #End Region
    
    #Region "Constructor"
        Private Sub New()
            'prevent construction
        End Sub
    #End Region
    
    
    #Region "Shared Functions"
        Public Shared Function GetSignatureTypeNameFromType(ByVal signatureType As enumerations.OAuthEnumerations.SignatureTypes) As String
            Select Case signatureType
                Case enumerations.OAuthEnumerations.SignatureTypes.HmacSha1
                    Return "HMAC-SHA1"
                Case Else
                    Return String.Empty
            End Select
        End Function
    
        Public Shared Function GenerateTimeStamp() As String
            'Implementation of UNIX current UTC time
            Dim _ts As TimeSpan = DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0, 0)
            Return Convert.ToInt64(_ts.TotalSeconds).ToString(CultureInfo.InvariantCulture)
        End Function
    
        Public Shared Function GenerateNonce() As String
            'Some random Number
            Return New Random().Next(123400, 9999999).ToString
        End Function
    
        Public Shared Function UrlEncode(ByVal value As String) As String
            Dim _result As New StringBuilder
    
            If (String.IsNullOrEmpty(value)) Then
                Return value
            End If
    
            For Each _symbol As Char In value
                If unreservedChars.IndexOf(_symbol) <> -1 Then
                    _result.Append(_symbol)
                Else
                    _result.Append(String.Format("%{0}", String.Format("{0:X2}", Asc(_symbol))))
                End If
            Next
    
            Return _result.ToString
        End Function
    
        ''' <summary>
        '''Generates a signature using the specified signatureType 
        '''    </summary>		
        '''    <param name="url">The full url that needs to be signed including its non OAuth url parameters</param>
        '''    <param name="consumerKey">The consumer key</param>
        '''    <param name="consumerSecret">The consumer seceret</param>
        '''    <param name="token">The token, if available. If not available pass null or an empty string</param>
        '''    <param name="tokenSecret">The token secret, if available. If not available pass null or an empty string</param>
        '''    <param name="httpMethod">The http method used. Must be a valid HTTP method verb (POST,GET,PUT, etc)</param>
        '''   <param name="signatureType">The type of signature to use</param>
        '''   <returns>A base64 string of the hash value</returns>
        Public Shared Function GenerateSignature(ByVal url As Uri, ByVal consumerKey As String, ByVal consumerSecret As String, ByVal token As String, ByVal tokenSecret As String, ByVal httpMethod As String, ByVal timeStamp As String, ByVal nonce As String, ByVal signatureType As enumerations.OAuthEnumerations.SignatureTypes, ByRef normalizedUrl As String, ByRef normalizedRequestParameters As String) As String
            normalizedUrl = String.Empty
            normalizedRequestParameters = String.Empty
    
            Dim _signatureBase As String
            Dim _hash As HMACSHA1
    
            Select Case signatureType
                Case enumerations.OAuthEnumerations.SignatureTypes.HmacSha1
                    _signatureBase = GenerateSignatureBase(url, consumerKey, token, tokenSecret, httpMethod, timeStamp, nonce, enumerations.OAuthEnumerations.SignatureTypes.HmacSha1, normalizedUrl, normalizedRequestParameters)
    
                    Dim _sb As New StringBuilder
                    With _sb
                        .Append(UrlEncode(consumerSecret))
                        .Append("&")
    
                        If (String.IsNullOrEmpty(tokenSecret)) Then
                            .Append("")
                        Else
                            .Append(UrlEncode(tokenSecret))
                        End If
                    End With
    
                    _hash = New HMACSHA1
                    _hash.Key = Encoding.ASCII.GetBytes(_sb.ToString)
    
                    Return GenerateSignatureUsingHash(_signatureBase, _hash)
    
                Case Else
                    Throw New NotImplementedException
    
            End Select
        End Function
    
        Public Shared Function GenerateSignatureUsingHash(ByVal signatureBase As String, ByVal hash As HashAlgorithm) As String
            Return ComputeHash(hash, signatureBase)
        End Function
    
        Public Shared Function GenerateSignatureBase(ByVal url As Uri, ByVal consumerKey As String, ByVal token As String, ByVal tokenSecret As String, ByVal httpMethod As String, ByVal timeStamp As String, ByVal nonce As String, ByVal signatureType As enumerations.OAuthEnumerations.SignatureTypes, ByRef normalizedUrl As String, ByRef normalizedRequestParameters As String) As String
            Dim _SignatureTypeName As String = GetSignatureTypeNameFromType(signatureType)
    
            If String.IsNullOrEmpty(token) Then
                token = String.Empty
            End If
    
            If String.IsNullOrEmpty(tokenSecret) Then
                tokenSecret = String.Empty
            End If
    
            If String.IsNullOrEmpty(consumerKey) Then
                Throw New ArgumentNullException("consumerKey")
            End If
    
            If String.IsNullOrEmpty(httpMethod) Then
                Throw New ArgumentNullException("httpMethod")
            End If
    
            If String.IsNullOrEmpty(_SignatureTypeName) Then
                Throw New ArgumentNullException("SignatureType")
            End If
    
            normalizedUrl = String.Empty
            normalizedRequestParameters = String.Empty
    
            Dim _params As List(Of QueryParameter) = getqueryparameters(url.Query)
    
            With _params
                .Add(New QueryParameter(OAuthVersionKey, OAuthVersion))
                .Add(New QueryParameter(OAuthNonceKey, nonce))
                .Add(New QueryParameter(OAuthTimestampKey, timeStamp))
                .Add(New QueryParameter(OAuthSignatureMethodKey, _SignatureTypeName))
                .Add(New QueryParameter(OAuthConsumerKeyKey, consumerKey))
    
                If Not (String.IsNullOrEmpty(token)) Then
                    .Add(New QueryParameter(OAuthTokenKey, token))
                End If
    
                .Sort(New QueryParameterComparer)
            End With
    
            normalizedUrl = String.Format("{0}://{1}", url.Scheme, url.Host)
    
            If Not ((url.Scheme = "http" AndAlso url.Port = 80) OrElse (url.Scheme = "https" AndAlso url.Port = 443)) Then
                normalizedUrl = String.Format("{0}:{1}", normalizedUrl, url.Port)
            End If
    
            normalizedUrl = String.Format("{0}{1}", normalizedUrl, url.AbsolutePath)
    
            normalizedRequestParameters = NormalizeRequestParameters(_params)
    
            Dim _sb As New StringBuilder
            With _sb
                .AppendFormat(CultureInfo.InvariantCulture, "{0}&", httpMethod.ToUpper)
                .AppendFormat(CultureInfo.InvariantCulture, "{0}&", UrlEncode(normalizedUrl))
                .AppendFormat(CultureInfo.InvariantCulture, "{0}", UrlEncode(normalizedRequestParameters))
            End With
    
            Return _sb.ToString
    
        End Function
    #End Region
    
    #Region "Private Methods"
        Private Shared Function ComputeHash(ByVal hashAlgorithm As HashAlgorithm, ByVal data As String) As String
            If hashAlgorithm Is Nothing Then
                Throw New ArgumentNullException("hashAlgorithm")
            End If
    
            If String.IsNullOrEmpty(data) Then
                Throw New ArgumentNullException("data")
            End If
    
            Dim _dataBuffer As Byte() = Encoding.ASCII.GetBytes(data)
            Dim _hashBytes As Byte() = hashAlgorithm.ComputeHash(_dataBuffer)
    
            Return Convert.ToBase64String(_hashBytes)
        End Function
    
    
        Private Shared Function NormalizeRequestParameters(ByVal parameters As IList(Of QueryParameter)) As String
    
            Dim _p As QueryParameter
            Dim _sb As New StringBuilder
    
            For i As Integer = 0 To parameters.count - 1
                _p = parameters(i)
                _sb.AppendFormat(CultureInfo.InvariantCulture, "{0}={1}", _p.Name, _p.Value)
    
                If i < parameters.count - 1 Then
                    _sb.Append("&")
                End If
            Next
    
            Return _sb.ToString
    
        End Function
    
        Private Shared Function GetQueryParameters(ByVal parameters As String) As List(Of QueryParameter)
            If (parameters.StartsWith("?")) Then
                parameters = parameters.Remove(0, 1)
            End If
    
            Dim _result As New List(Of QueryParameter)
            Dim _p As String() = parameters.Split("&"c)
    
            Dim _temp As String()
    
            If Not (String.IsNullOrEmpty(parameters)) Then
    
                For Each s As String In _p
                    If Not (String.IsNullOrEmpty(s)) AndAlso Not (s.StartsWith(OAuthParameterExclusionPrefix)) Then 'AndAlso (s.StartsWith(OAuthParameterPrefix)) Then
                        If s.IndexOf("=") > -1 Then
                            _temp = s.Split("="c)
                            _result.Add(New QueryParameter(_temp(0), _temp(1)))
                        Else
                            _result.Add(New QueryParameter(s, String.Empty))
                        End If
                    End If
    
                Next
    
            End If
    
            Return _result
    
        End Function
    #End Region
    
    
    End Class
