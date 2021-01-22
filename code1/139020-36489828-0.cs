    public static class SmtpClientExtensions
    {
        static System.IO.StreamWriter sw = null;
        static System.Net.Sockets.TcpClient tcpc = null;
        static System.Net.Security.SslStream ssl = null;
        static int bytes = -1;
        static byte[] buffer;
        static System.Text.StringBuilder sb = new System.Text.StringBuilder();
        static byte[] dummy;
        /// <summary>
        /// Communication with server
        /// </summary>
        /// <param name="command">The command beeing sent</param>
        private static void SendCommandAndReceiveResponse(string command)
        {
            try
            {
                if (command != "")
                {
                    if (tcpc.Connected)
                    {
                        dummy = System.Text.Encoding.ASCII.GetBytes(command);
                        ssl.Write(dummy, 0, dummy.Length);
                    }
                    else
                    {
                        throw new System.ApplicationException("TCP CONNECTION DISCONNECTED");
                    }
                }
                ssl.Flush();
                buffer = new byte[2048];
                bytes = ssl.Read(buffer, 0, 2048);
                sb.Append(System.Text.Encoding.ASCII.GetString(buffer));
                System.Diagnostics.Debug.WriteLine(sb.ToString());
                sw.WriteLine(sb.ToString());
                sb = new System.Text.StringBuilder();
            }
            catch (System.Exception ex)
            {
                throw new System.ApplicationException(ex.Message);
            }
        }
        /// <summary>
        /// Saving a mail message before beeing sent by the SMTP client
        /// </summary>
        /// <param name="self">The caller</param>
        /// <param name="imapServer">The address of the IMAP server</param>
        /// <param name="imapPort">The port of the IMAP server</param>
        /// <param name="userName">The username to log on to the IMAP server</param>
        /// <param name="password">The password to log on to the IMAP server</param>
        /// <param name="sentFolderName">The name of the folder where the message will be saved</param>
        /// <param name="mailMessage">The message being saved</param>
        public static void SendAndSaveMessageToIMAP(this System.Net.Mail.SmtpClient self, System.Net.Mail.MailMessage mailMessage, string imapServer, int imapPort, string userName, string password, string sentFolderName)
        {
            try
            {
                tcpc = new System.Net.Sockets.TcpClient(imapServer, imapPort);
                ssl = new System.Net.Security.SslStream(tcpc.GetStream());
                ssl.AuthenticateAsClient(imapServer);
                SendCommandAndReceiveResponse("");
                SendCommandAndReceiveResponse(string.Format("$ LOGIN {1} {2}  {0}", System.Environment.NewLine, userName, password));
                using (var m = mailMessage.RawMessage())
                {
                    m.Position = 0;
                    var sr = new System.IO.StreamReader(m);
                    var myStr = sr.ReadToEnd();
                    SendCommandAndReceiveResponse(string.Format("$ APPEND {1} (\\Seen) {{{2}}}{0}", System.Environment.NewLine, sentFolderName, myStr.Length));
                    SendCommandAndReceiveResponse(string.Format("{1}{0}", System.Environment.NewLine, myStr));
                }
                SendCommandAndReceiveResponse(string.Format("$ LOGOUT{0}", System.Environment.NewLine));
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("error: " + ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
                if (ssl != null)
                {
                    ssl.Close();
                    ssl.Dispose();
                }
                if (tcpc != null)
                {
                    tcpc.Close();
                }
            }
            self.Send(mailMessage);
        }
    }
    public static class MailMessageExtensions
    {
        private static readonly System.Reflection.BindingFlags Flags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
        private static readonly System.Type MailWriter = typeof(System.Net.Mail.SmtpClient).Assembly.GetType("System.Net.Mail.MailWriter");
        private static readonly System.Reflection.ConstructorInfo MailWriterConstructor = MailWriter.GetConstructor(Flags, null, new[] { typeof(System.IO.Stream) }, null);
        private static readonly System.Reflection.MethodInfo CloseMethod = MailWriter.GetMethod("Close", Flags);
        private static readonly System.Reflection.MethodInfo SendMethod = typeof(System.Net.Mail.MailMessage).GetMethod("Send", Flags);
        /// <summary>
        /// A little hack to determine the number of parameters that we
        /// need to pass to the SaveMethod.
        /// </summary>
        private static readonly bool IsRunningInDotNetFourPointFive = SendMethod.GetParameters().Length == 3;
        /// <summary>
        /// The raw contents of this MailMessage as a MemoryStream.
        /// </summary>
        /// <param name="self">The caller.</param>
        /// <returns>A MemoryStream with the raw contents of this MailMessage.</returns>
        public static System.IO.MemoryStream RawMessage(this System.Net.Mail.MailMessage self)
        {
            var result = new System.IO.MemoryStream();
            var mailWriter = MailWriterConstructor.Invoke(new object[] { result });
            SendMethod.Invoke(self, Flags, null, IsRunningInDotNetFourPointFive ? new[] { mailWriter, true, true } : new[] { mailWriter, true }, null);
            result = new System.IO.MemoryStream(result.ToArray());
            CloseMethod.Invoke(mailWriter, Flags, null, new object[] { }, null);
            return result;
        }
    }
