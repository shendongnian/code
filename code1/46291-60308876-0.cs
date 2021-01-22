    Private Sub RecData(ByVal AR As IAsyncResult)
        Dim Socket As Socket = AR.AsyncState
        If Socket.Connected = False And Socket.Available = False Then
            Debug.Print("Detected Disconnected Socket - " + Socket.RemoteEndPoint.ToString)
            Exit Sub
        End If
        Dim BytesRead As Int32 = Socket.EndReceive(AR)
        If BytesRead = 0 Then
            Debug.Print("Detected Disconnected Socket - Bytes Read = 0 - " + Socket.RemoteEndPoint.ToString)
            UpdateText("Client " + Socket.RemoteEndPoint.ToString + " has disconnected from Server.")
            Socket.Close()
            Exit Sub
        End If
        Dim msg As String = System.Text.ASCIIEncoding.ASCII.GetString(ByteData)
        Erase ByteData
        ReDim ByteData(1024)
        ClientSocket.BeginReceive(ByteData, 0, ByteData.Length, SocketFlags.None, New AsyncCallback(AddressOf RecData), ClientSocket)
        UpdateText(msg)
    End Sub
