    Imports System.Net.Sockets
    Imports System.Text
    Class TCPSrv
        Shared Sub Main()
            ' Must listen on correct port- must be same as port client wants to connect on.
            Const portNumber As Integer = 51124
            Dim tcpListener As New TcpListener(portNumber)
            tcpListener.Start()
            Console.WriteLine("Waiting for connection...")
            Try
                'Accept the pending client connection and return 
                'a TcpClient initialized for communication. 
                Dim tcpClient As TcpClient = tcpListener.AcceptTcpClient()
                Console.WriteLine("Connection accepted.")
                ' Get the stream
                Dim networkStream As NetworkStream = tcpClient.GetStream()
                ' Read the stream into a byte array
                Dim bytes(tcpClient.ReceiveBufferSize) As Byte
                networkStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))
                tcpClient.Close()
                tcpListener.Stop()
                Console.WriteLine("exit")
                Console.ReadLine()
            Catch e As Exception
                Console.WriteLine(e.ToString())
                Console.ReadLine()
            End Try
        End Sub
       End Class
