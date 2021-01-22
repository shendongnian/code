      Public Function SignCommandUrl(ByVal commandUrl As String) As String
            Return SignCommandUrl(commandUrl, Nothing, Nothing)
        End Function
    
        Public Function SignCommandUrl(ByVal commandUrl As String, ByVal overrideToken As String, ByVal overrideTokenSecret As String) As String
            Dim _commandUri = New Uri(commandUrl)
            Dim _oAuthSignature As String
            Dim _oAuthTimeStamp As String = SharedOAuth.GenerateTimeStamp
            Dim _oAuthNOnce As String = SharedOAuth.GenerateNonce
            Dim _oAuth_normalized_url As String = String.Empty
            Dim _oAuth_normalized_params As String = String.Empty
    
            If Not (String.IsNullOrEmpty(overrideToken)) OrElse Not (String.IsNullOrEmpty(overrideTokenSecret)) Then
                _oAuthSignature = SharedOAuth.GenerateSignature(_commandUri, CONSUMER_KEY, CONSUMER_SECRET, overrideToken, overrideTokenSecret, "GET", _oAuthTimeStamp, _oAuthNOnce, enumerations.OAuthEnumerations.SignatureTypes.HmacSha1, _oAuth_normalized_url, _oAuth_normalized_params)
            Else
    
                If MasterAccessToken Is Nothing Then
                    _oAuthSignature = SharedOAuth.GenerateSignature(_commandUri, CONSUMER_KEY, CONSUMER_SECRET, String.Empty, String.Empty, "GET", _oAuthTimeStamp, _oAuthNOnce, enumerations.OAuthEnumerations.SignatureTypes.HmacSha1, _oAuth_normalized_url, _oAuth_normalized_params)
                Else
                    _oAuthSignature = SharedOAuth.GenerateSignature(_commandUri, CONSUMER_KEY, CONSUMER_SECRET, SharedOAuth.UrlEncode(MasterAccessToken.Token), MasterAccessToken.TokenSecret, "GET", _oAuthTimeStamp, _oAuthNOnce, enumerations.OAuthEnumerations.SignatureTypes.HmacSha1, _oAuth_normalized_url, _oAuth_normalized_params)
                End If
            End If
    
            'Get a token
            Dim _sb As New System.Text.StringBuilder
            With _sb
                .Append(_oAuth_normalized_url)
                .Append("?")
                .Append(_oAuth_normalized_params)
                .Append("&")
                .Append("oauth_signature")
                .Append("=")
                .Append(SharedOAuth.UrlEncode(_oAuthSignature))
            End With
    
            Return _sb.ToString
        End Function
    
        Public Function BuildPostHeader(ByVal commandUrl As String) As String
            Dim _commandUri = New Uri(commandUrl)
            Dim _oAuthTimeStamp As String = SharedOAuth.GenerateTimeStamp
            Dim _oAuthNOnce As String = SharedOAuth.GenerateNonce
            Dim _oAuth_normalized_url As String = String.Empty
            Dim _oAuth_normalized_params As String = String.Empty
            Dim _oAuthSignature As String
    
            If MasterAccessToken Is Nothing Then
                _oAuthSignature = SharedOAuth.GenerateSignature(_commandUri, CONSUMER_KEY, CONSUMER_SECRET, String.Empty, String.Empty, "POST", _oAuthTimeStamp, _oAuthNOnce, enumerations.OAuthEnumerations.SignatureTypes.HmacSha1, _oAuth_normalized_url, _oAuth_normalized_params)
            Else
                _oAuthSignature = SharedOAuth.GenerateSignature(_commandUri, CONSUMER_KEY, CONSUMER_SECRET, SharedOAuth.UrlEncode(MasterAccessToken.Token), MasterAccessToken.TokenSecret, "POST", _oAuthTimeStamp, _oAuthNOnce, enumerations.OAuthEnumerations.SignatureTypes.HmacSha1, _oAuth_normalized_url, _oAuth_normalized_params)
            End If
    
    
            Dim _sb As New System.Text.StringBuilder
            With _sb
                .Append("Authorization: OAuth oauth_version=""1.0"", ")
                .AppendFormat("oauth_nonce=""{0}"", ", _oAuthNOnce)
                .AppendFormat("oauth_timestamp=""{0}"", ", _oAuthTimeStamp)
                .AppendFormat("oauth_consumer_key=""{0}"", ", CONSUMER_KEY)
                .AppendFormat("oauth_token=""{0}"", ", MasterAccessToken.Token)
                .Append("oauth_signature_method=""HMAC-SHA1"", ")
                .AppendFormat("oauth_signature=""{0}""", _oAuthSignature)
            End With
    
            Return _sb.ToString
        End Function
    
        Public Shared Function PostRequestReturnCollection(ByVal commandUrl As String) As NameValueCollection
            Dim _nameValCollection As NameValueCollection
    
            Dim _request As HttpWebRequest = CType(WebRequest.Create(commandUrl), HttpWebRequest)
    
            Using _response As HttpWebResponse = CType(_request.GetResponse, HttpWebResponse)
                Using _reader As TextReader = New StreamReader(_response.GetResponseStream)
                    _nameValCollection = HttpUtility.ParseQueryString(_reader.ReadToEnd)
                End Using
            End Using
    
            Return _nameValCollection
        End Function
