    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    namespace Test2
    {
        public class Server
        {
            private readonly TcpListener _listener = new TcpListener(1234);
            public void Start()
            {
                _listener.BeginAcceptTcpClient(OnClient, null);
            }
            private void OnClient(IAsyncResult ar)
            {
                // End async accept and start wait for a new connection again
                TcpClient client = _listener.EndAcceptTcpClient(ar);
                _listener.BeginAcceptTcpClient(OnClient, null);
                // Let's start receiving files from the accepted client.
                var context = new Context {Client = client, Buffer = new byte[8196]};
                client.GetStream().BeginRead(context.Buffer, 0, context.Buffer.Length, OnReceive, context);
            }
            /// <summary>
            /// Got some stuff from a client
            /// </summary>
            /// <param name="ar"></param>
            private void OnReceive(IAsyncResult ar)
            {
                // got a file command
                var context = (Context) ar.AsyncState;
                int bytesRead = context.Client.GetStream().EndRead(ar);
                string cmd = Encoding.UTF8.GetString(context.Buffer, 0, bytesRead);
                string[] parts = cmd.Split(';');
                string command = parts[0];
                // want to send another file
                if (command == "sendfile")
                {
                    // context info for receiving files
                    var client = new FileClient();
                    client.FileName = parts[1];
                    client.Size = long.Parse(parts[2]);
                    client.FileStream = new FileStream("C:\\" + client.FileName, FileMode.CreateNew, FileAccess.Write);
                    // startup listener where we are going to receive the file.
                    var listener = new TcpListener(IPAddress.Any, 0); // get a kernelassigned number
                    client.Listener = listener;
                    listener.Start();
                    listener.BeginAcceptTcpClient(OnFileSocket, client);
                    // send reply
                    var ep = (IPEndPoint) listener.LocalEndpoint;
                    byte[] reply = Encoding.UTF8.GetBytes(ep.Port.ToString());
                    context.Client.GetStream().Write(reply, 0, reply.Length);
                }
            }
            // Receiving the actual files.
            private void OnFileSocket(IAsyncResult ar)
            {
                var client = (FileClient) ar.AsyncState;
                client.Socket = client.Listener.EndAcceptTcpClient(ar);
                var buffer = new byte[8192];
                client.Buffer = buffer;
                client.Socket.GetStream().BeginRead(buffer, 0, buffer.Length, OnReceiveFile, client);
            }
            private void OnReceiveFile(IAsyncResult ar)
            {
                var client = (FileClient) ar.AsyncState;
                int bytesRead = client.Socket.GetStream().EndRead(ar);
                client.Received += bytesRead;
                client.FileStream.Write(client.Buffer, 0, bytesRead);
                // recieved complete file, disconnect and exit.
                if (client.Received == client.Size)
                {
                    client.FileStream.Close();
                    client.Socket.Close();
                    return;
                }
                client.Socket.GetStream().BeginRead(client.Buffer, 0, client.Buffer.Length, OnReceiveFile, client);
            }
            #region Nested type: Context
            private class Context
            {
                public byte[] Buffer;
                public TcpClient Client;
            }
            #endregion
            #region Nested type: FileClient
            private class FileClient
            {
                public byte[] Buffer;
                public string FileName;
                public FileStream FileStream;
                public TcpListener Listener;
                public long Received;
                public long Size;
                public TcpClient Socket;
            }
            #endregion
        }
    }
