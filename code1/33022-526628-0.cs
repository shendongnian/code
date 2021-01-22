    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.IO.Compression;
    
    namespace HttpUsingSockets {
        public class Program {
            private static readonly Encoding DefaultEncoding = Encoding.ASCII;
            private static readonly byte[] LineTerminator = new byte[] { 13, 10 };
    
            public static void Main(string[] args) {
                var host = "stackoverflow.com";
                var url = "/questions/523930/sockets-in-c-how-to-get-the-response-stream";
    
                IPHostEntry ipAddress = Dns.GetHostEntry(host);
                var ip = new IPEndPoint(ipAddress.AddressList[0], 80);
                using (var socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp)) {
                    socket.Connect(ip);
                    using (var n = new NetworkStream(socket)) {
                        SendRequest(n, new[] {"GET " + url + " HTTP/1.1", "Host: " + host, "Connection: Close", "Accept-Encoding: gzip"});
    
                        var headers = new Dictionary<string, string>();
                        while (true) {
                            var line = ReadLine(n);
                            if (line.Length == 0) {
                                break;
                            }
                            int index = line.IndexOf(':');
                            headers.Add(line.Substring(0, index), line.Substring(index + 2));
                        }
    
                        string contentEncoding;
                        if (headers.TryGetValue("Content-Encoding", out contentEncoding)) {
                            Stream responseStream = n;
                            if (contentEncoding.Equals("gzip")) {
                                responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                            }
                            else if (contentEncoding.Equals("deflate")) {
                                responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);
                            }
    
                            var memStream = new MemoryStream();
    
                            var respBuffer = new byte[4096];
                            try {
                                int bytesRead = responseStream.Read(respBuffer, 0, respBuffer.Length);
                                while (bytesRead > 0) {
                                    memStream.Write(respBuffer, 0, bytesRead);
                                    bytesRead = responseStream.Read(respBuffer, 0, respBuffer.Length);
                                }
                            }
                            finally {
                                responseStream.Close();
                            }
    
                            var body = DefaultEncoding.GetString(memStream.ToArray());
                            Console.WriteLine(body);
                        }
                        else {
                            while (true) {
                                var line = ReadLine(n);
                                if (line == null) {
                                    break;
                                }
                                Console.WriteLine(line);
                            }
                        }
                    }
                }
            }
    
            static void SendRequest(Stream stream, IEnumerable<string> request) {
                foreach (var r in request) {
                    var data = DefaultEncoding.GetBytes(r);
                    stream.Write(data, 0, data.Length);
                    stream.Write(LineTerminator, 0, 2);
                }
                stream.Write(LineTerminator, 0, 2);
                // Eat response
                var response = ReadLine(stream);
            }
    
            static string ReadLine(Stream stream) {
                var lineBuffer = new List<byte>();
                while (true) {
                    int b = stream.ReadByte();
                    if (b == -1) {
                        return null;
                    }
                    if (b == 10) {
                        break;
                    }
                    if (b != 13) {
                        lineBuffer.Add((byte)b);
                    }
                }
                return DefaultEncoding.GetString(lineBuffer.ToArray());
            }
        }
    }
