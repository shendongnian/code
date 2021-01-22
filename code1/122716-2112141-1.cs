    Public Property Url() As String
        Get
            Return _url.Trim()
        End Get
        Set(ByVal value As String)
            _url = value.Trim()
        End Set
    End Property
    
    Public ReadOnly Property Request() As System.Net.HttpWebRequest
        Get
            If _request Is Nothing AndAlso Me.Url.Trim.Length > 0 Then _
                _request = CType(System.Net.HttpWebRequest.Create(Me.Url & "?wsdl"), _
                    System.Net.HttpWebRequest)
            Return _request
        End Get
    End Property
    
    Public ReadOnly Property Response() As System.Net.HttpWebResponse
        Get
            If _response Is Nothing AndAlso Me.Url.Trim().Length > 0 Then _
                _response = CType(Request.GetResponse(), System.Net.HttpWebResponse)
            Return _response
        End Get
    End Property
