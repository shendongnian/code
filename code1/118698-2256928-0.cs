        Public Function GetClientInfo() As String
            Dim context As OperationContext = System.ServiceModel.OperationContext.Current
            Dim prop As RemoteEndpointMessageProperty = _
                CType(context.IncomingMessageProperties(RemoteEndpointMessageProperty.Name),  _
                RemoteEndpointMessageProperty)
            Dim remoteIP As String = prop.Address
            If remoteIP.IndexOf(":") > -1 Then
                'it's IPv6
                For i As Integer = 0 To System.Net.Dns.GetHostEntry(remoteIP).AddressList.Length - 1
                    Dim remipv4 As String = System.Net.Dns.GetHostEntry(remoteIP).AddressList(i).ToString
                    If remipv4.IndexOf(".") > -1 Then Return remipv4
                Next
                'not found, return v6 address
                Return remoteIP
            Else
                Return remoteIP
            End If
        End Function
