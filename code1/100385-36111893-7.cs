    internal class SmtpConnectorWithSsl : SmtpConnectorBase {
        private SslStream _sslStream = null;
        private TcpClient _client = null;
        public SmtpConnectorWithSsl(string smtpServerAddress, int port) : base(smtpServerAddress, port) {
            TcpClient client = new TcpClient(smtpServerAddress, port);
            _sslStream = new SslStream(
                client.GetStream(),
                false,
                new RemoteCertificateValidationCallback(ValidateServerCertificate),
                null
                );
            // The server name must match the name on the server certificate.
            try {
                _sslStream.AuthenticateAsClient(smtpServerAddress);
            } catch (AuthenticationException e) {
                _sslStream = null;
                Console.WriteLine("Exception: {0}", e.Message);
                if (e.InnerException != null) {
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                }
                Console.WriteLine("Authentication failed - closing the connection.");
                client.Close();
            }
        }
        ~SmtpConnectorWithSsl() {
            try {
                if (_sslStream != null) {
                    _sslStream.Close();
                    _sslStream.Dispose();
                    _sslStream = null;
                }
            } catch (Exception) {
                ;
            }
            try {
                if (_client != null) {
                    _client.Close();
                    _client = null;
                }
            } catch (Exception) {
                ;
            }
        }
        // The following method is invoked by the RemoteCertificateValidationDelegate.
        private static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors) {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;
            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);
            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }
        public override bool CheckResponse(int expectedCode) {
            if (_sslStream == null) {
                return false;
            }
            var message = ReadMessageFromStream(_sslStream);
            int responseCode = Convert.ToInt32(message.Substring(0, 3));
            if (responseCode == expectedCode) {
                return true;
            }
            return false;
        }
        public override void SendData(string data) {
            byte[] messsage = Encoding.UTF8.GetBytes(data);
            // Send hello message to the server. 
            _sslStream.Write(messsage);
            _sslStream.Flush();
        }
        private string ReadMessageFromStream(SslStream stream) {
            byte[] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            int bytes = -1;
            do {
                bytes = stream.Read(buffer, 0, buffer.Length);
                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);
                // Check for EOF.
                if (messageData.ToString().IndexOf(EOF) != -1) {
                    break;
                }
            } while (bytes != 0);
            return messageData.ToString();
        }
    }
