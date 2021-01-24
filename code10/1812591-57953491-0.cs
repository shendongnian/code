    private readonly string hostname = "gateway.sandbox.push.apple.com";
    private readonly int port = 2195;
    public async Task<RestResult<JObject>> SendPushNotification(string deviceToken, string message)
        {
            this.log?.LogInformation("Trying to send push notification.");
            X509Certificate2Collection certificatesCollection;
            // Setup and read the certificate
            // NOTE: You should get the certificate from your apple developer account.
            try
            {
                string certificatePath = Settings.Apn.Certificate;
                X509Certificate2 clientCertificate = new X509Certificate2(
                    File.ReadAllBytes(certificatePath),
                    Settings.Apn.Password);
                certificatesCollection = new X509Certificate2Collection(clientCertificate);
                this.log?.LogInformation("Setup certificates.");
            }
            catch (Exception e)
            {
                this.log?.LogError(e.ToString());
                return new RestResult<JObject> { Result = "exception", Message = "Failed to setup certificates." };
            }
            // Setup a tcp connection to the apns
            TcpClient client = new TcpClient(AddressFamily.InterNetwork);
            this.log?.LogInformation("Created new TcpClient.");
            try
            {
                IPHostEntry host = Dns.GetHostEntry(this.hostname);
                await client.ConnectAsync(host.AddressList[0], this.port);
                this.log?.LogInformation($"Opened connection to {this.hostname}:{this.port}.");
            }
            catch (Exception e)
            {
                this.log?.LogError("Failed to open tcp connection to the apns.");
                this.log?.LogError(e.ToString());
            }
            
            // Validate the Certificate you get from the APN (for more information read the documentation:
            // https://developer.apple.com/library/archive/documentation/NetworkingInternet/Conceptual/RemoteNotificationsPG/APNSOverview.html#//apple_ref/doc/uid/TP40008194-CH8-SW1).
            SslStream sslStream = new SslStream(
                client.GetStream(),
                false,
                new RemoteCertificateValidationCallback(this.ValidateServerCertificate),
                null);
            try
            {
                await sslStream.AuthenticateAsClientAsync(this.hostname, certificatesCollection, SslProtocols.Tls, false);
                MemoryStream memoryStream = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(memoryStream);
                writer.Write((byte)0);
                writer.Write((byte)0);
                writer.Write((byte)32);
                writer.Write(HexStringToByteArray(deviceToken.ToUpper()));
                // Creating an payload object to send key values to the apns
                JObject aps = new JObject
                                  {
                                      new JProperty("alert", message),
                                      new JProperty("badge", 0),
                                      new JProperty("sound", "default")
                                  };
                JObject payload = new JObject
                                      {
                                        new JProperty("aps", aps)
                                      };
                string payloadString = JsonConvert.SerializeObject(payload);
                writer.Write((byte)0);
                writer.Write((byte)payloadString.Length);
                byte[] b1 = System.Text.Encoding.UTF8.GetBytes(payloadString);
                writer.Write(b1);
                writer.Flush();
                byte[] array = memoryStream.ToArray();
                sslStream.Write(array);
                sslStream.Flush();
                client.Dispose();
            }
            catch (AuthenticationException ex)
            {
                this.log?.LogError(ex.ToString());
                client.Dispose();
                return new RestResult<JObject> { Result = "exception", Message = "Authentication Exception." };
            }
            catch (Exception e)
            {
                this.log?.LogError(e.ToString());
                client.Dispose();
                return new RestResult<JObject> { Result = "exception", Message = "Exception was thrown." };
            }
            this.log?.LogInformation("Notification sent.");
            return new RestResult<JObject> { Result = "success", Message = "Notification sent. Check your device." };
        }
        #region Helper methods
        private static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
        // The following method is invoked by the RemoteCertificateValidationDelegate.
        private bool ValidateServerCertificate(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                this.log?.LogInformation("Server Certificate validated.");
                return true;
            }
            this.log?.LogError($"Server Certificate error: {sslPolicyErrors}");
            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }
        #endregion
