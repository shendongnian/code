    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    namespace Test2
    {
        internal class Client
        {
            private readonly IPAddress _server;
            private readonly TcpClient _tcpClient = new TcpClient();
            public Client(IPAddress server)
            {
                _server = server;
                _tcpClient = new TcpClient();
            }
            public void Connect()
            {
                _tcpClient.Connect(new IPEndPoint(_server, 1234));
            }
            // asks server on which port the file should be sent.
            private int RequestPort(string fileName, long length)
            {
                // lock tpcClient for each request, so we dont mix up the responses.
                lock (_tcpClient)
                {
                    // send request
                    byte[] bytes = Encoding.UTF8.GetBytes("sendfile;" + fileName + ";" + length);
                    _tcpClient.GetStream().Write(bytes, 0, bytes.Length);
                    // get reply
                    var buffer = new byte[1024];
                    int bytesRead = _tcpClient.GetStream().Read(buffer, 0, buffer.Length);
                    string reply = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    // error message or port?
                    int port;
                    if (!int.TryParse(reply, out port))
                        throw new InvalidOperationException("Server sent an error:" + reply);
                    return port;
                }
            }
            public void SendFiles(string[] fileNames)
            {
                // Use a buffer to not preserve memory (instead of reading whole file into memory)
                var buffer = new byte[8192];
                foreach (string fileName in fileNames)
                {
                    using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        // Send on commandchannel that we want to send a file.
                        int filePort = RequestPort(Path.GetFileName(fileName), fileStream.Length);
                        var client = new TcpClient(new IPEndPoint(_server, filePort));
                        NetworkStream stream = client.GetStream();
                        // repeat until there are no more bytes to read.
                        int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                        while (bytesRead > 0)
                        {
                            stream.Write(buffer, 0, bytesRead);
                            bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                        }
                        stream.Close();
                        client.Close();
                    }
                }
            }
        }
    }
