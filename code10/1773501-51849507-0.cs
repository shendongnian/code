        public bool VerifyThatCanAuthenticateAsClient()
        {
            bool bSuccess = false;
            TcpClient tcpClient = null;
            SslStream sslStream = null;
            try
            {
                tcpClient = new TcpClient(
                    _sHostname,
                    _iPort
                );
                bSuccess = true;
            }
            catch(Exception ex)
            {
                //log exception
            }
            if(bSuccess)
            {
                bSuccess = false;
                try
                {
                    sslStream = new SslStream(
                        tcpClient.GetStream(),
                        false,
                        new RemoteCertificateValidationCallback(ValidateServerCertificate),
                        new LocalCertificateSelectionCallback(SelectLocalCertificate),
                        EncryptionPolicy.RequireEncryption
                        );
                    bSuccess = true;
                }
                catch (Exception ex)
                {
                    //log exception
                }
            }
            if (bSuccess)
            {
                bSuccess = false;
                try
                {
                    sslStream.AuthenticateAsClient(
                        _sHostname,
                        null,
                        System.Security.Authentication.SslProtocols.Tls12,
                        false
                        );
                    bSuccess = true;
                }
                catch (Exception ex)
                {
                    //log ex.message exception
                    if(ex.InnerException != null)
                    {
                        //log ex.innerexception.message
                        //this is what gives me the low level error that means its revoked if it is, or other specific tls error
                    }
                }
            }
            if(sslStream != null)
            {
                sslStream.Dispose();
            }
            if(tcpClient != null)
            {
                tcpClient.Dispose();
            }
            return bSuccess;
        }
