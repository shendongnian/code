        Private Sub sendData(ByVal zpl As String)
        Dim ns As System.Net.Sockets.NetworkStream = Nothing
        Dim socket As System.Net.Sockets.Socket = Nothing
        Dim printerIP As Net.IPEndPoint = Nothing
        Dim toSend As Byte()
        Try
            If printerIP Is Nothing Then
                'set the IP address
                printerIP = New Net.IPEndPoint(IPAddress.Parse(IP_ADDRESS), 9100)
            End If
            'Create a TCP socket
            socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            'Connect to the printer based on the IP address
            socket.Connect(printerIP)
            'create a new network stream based on the socket connection
            ns = New NetworkStream(socket)
            'convert the zpl command to a byte array
            toSend = System.Text.Encoding.ASCII.GetBytes(zpl)
            'send the zpl byte array over the networkstream to the connected printer
            ns.Write(toSend, 0, toSend.Length)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Cable Printer", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        Finally
            'close the networkstream and then the socket
            If Not ns Is Nothing Then
                ns.Close()
            End If
            If Not socket Is Nothing Then
                socket.Close()
            End If
        End Try
    End Sub
    Private Function createString() As String
        Dim command As String
        command = "^XA"
        command += "^LH20,25"
        If rdoSmall.Checked = True Then
            command += "^FO1,30^A0,N,25,25^FD"
        ElseIf rdoNormal.Checked = True Then
            command += "^FO1,30^A0,N,35,35^FD"
        Else
            command += "^FO1,30^A0,N,50,50^FD"
        End If
        command += txtInput.Text
        command += "^FS"
        command += "^XZ"
        Return command
    End Function
