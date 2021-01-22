    public class Pop3EMail
    {
        public long Number { get; set; }
        public long Bytes { get; set; }
        public bool Retrieved { get; set; }
        public string Body { get; set; }
    }
    public class SecurePop3Client : TcpClient, IDisposable
    {
        SslStream netStream;
        static ILog log = LogManager.GetLogger(typeof(SecurePop3Client));
        private SecurePop3Client()
        { }
        private void EstablishConnection(string serverAddress, int port, string sertificateName, string username, string password)
        {
            try
            {
                Connect(serverAddress, port);
                netStream = new SslStream(GetStream());
                netStream.AuthenticateAsClient(sertificateName);
                CheckResponse(GetServerResponse());
                CheckResponse(SendToServer(string.Format("USER {0}\r\n", username)));
                CheckResponse(SendToServer(string.Format("PASS {0}\r\n", password)));
                log.DebugFormat("Connected to {0}:{1}, with serificate :{2}", serverAddress, port, sertificateName);
            }
            catch (Exception e)
            {
                throw new SecurePop3Exception("Connecting to Email server failed", e);
            }
        }
        public void Disconnect()
        {
            CheckResponse(SendToServer("QUIT\r\n"));
            log.Debug("Disconnected from server");
        }
        public List<Pop3EMail> List()
        {
            string response;
            var ret = new List<Pop3EMail>();
            CheckResponse(SendToServer("LIST\r\n"));
            while (true)
            {
                response = GetServerResponse();
                if (response == ".\r\n")
                {
                    log.DebugFormat("Retrieved {0} messages from the server", ret.Count);
                    return ret;
                }
                else
                {
                    try
                    {
                        string[] values = response.Split(new char[] { ' ' });
                        Pop3EMail mail = new Pop3EMail
                        {
                            Number = Int32.Parse(values[0]),
                            Bytes = Int32.Parse(values[1]),
                            Retrieved = false
                        };
                        ret.Add(mail);
                    }
                    // catch (ArgumentNullException)
                    // catch (FormatException)
                    // catch (OverflowException)
                    // catch (IndexOutOfRangeException)
                    catch (Exception e)
                    {
                        throw new SecurePop3Exception("Parsing message list failed", e);
                    }
                }
            }
        }
        public void RetrieveBody(Pop3EMail mail)
        {
            string response;
            CheckResponse(SendToServer(string.Format("RETR {0}\r\n", mail.Number)));
            StringBuilder body = new StringBuilder();
            while (true)
            {
                response = GetServerResponse();
                if (response == ".\r\n")
                {
                    break;
                }
                else
                {
                    body.Append(response);
                }
            }
            mail.Retrieved = true;
            mail.Body = body.ToString();
            log.DebugFormat("Retrieved body of mail {0}", mail.Number);
        }
        public void Delete(Pop3EMail mail)
        {
            CheckResponse(SendToServer(string.Format("DELE {0}\r\n", mail.Number)));
            log.DebugFormat("Deleted Email {0}", mail.Number);
        }
        private string GetServerResponse()
        {
            byte[] buffer = new Byte[1024];
            int count = 0;
            while (true)
            {
                byte[] buff = new Byte[2];
                int bytes = netStream.Read(buff, 0, 1);
                if (bytes == 1)
                {
                    buffer[count] = buff[0];
                    count++;
                    if (buff[0] == '\n')
                    {
                        break;
                    }
                }
                else
                {
                    break;
                };
            };
            string retval = Encoding.ASCII.GetString(buffer, 0, count);
            log.DebugFormat("GOT FROM SERVER: {0}",retval);
            return retval;
        }
        private string SendToServer(string message)
        {
            try
            {
                byte[] buffer = new byte[1024];
                buffer = Encoding.ASCII.GetBytes(message);
                netStream.Write(buffer, 0, buffer.Length);
                log.DebugFormat("SEND TO SERVER: {0}", message);
                return GetServerResponse();
            }
            catch (Exception e)
            {
               throw new SecurePop3Exception(string.Format("Communication with server failed"), e);
            }
        }
        private void CheckResponse(string response)
        {
            if (string.IsNullOrEmpty(response) || response.Length < 3 || string.Compare(response.Substring(0, 3),"+OK",true) != 0)
            {
                throw new SecurePop3Exception(response);
            }
        }
        /// <summary>
        /// Factory
        /// </summary>
        /// <param name="serverAddress"></param>
        /// <param name="port"></param>
        /// <param name="sertificateName"></param>
        /// <returns></returns>
        public static SecurePop3Client Connect(string serverAddress, int port, string sertificateName, string username, string password)
        {
            SecurePop3Client client = new SecurePop3Client();
            client.EstablishConnection(serverAddress, port, sertificateName, username, password);
            return client;
        }
        #region Dispose Design Pattern Implementation
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Disposes the instance.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Disconnect();
                netStream.Dispose();
            }
            base.Dispose(disposing);
        }
        // Use C# destructor syntax for finalization code.
        ~SecurePop3Client()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
        #endregion
    }
