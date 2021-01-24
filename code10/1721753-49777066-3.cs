        using (var _tcpClient = new TcpClient(host, port))
        {
            var stream = _tcpClient.GetStream();
            using (var reader = new StreamReader(stream, Encoding.ASCII))
            using (var writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true })
            {                    
                writer.WriteLine(RequestBuilder.BuildConnectionRequest());
                var response = reader.ReadLine();
                var privateKey = ResidueUtils.GetRSAPrivateKey();
                var decryptedResponse = ResidueUtils.RsaDecryptWithPrivate(response.TrimBraces(), privateKey);
                var residueResponse = JsonHelper.Parse(decryptedResponse);
                if (residueResponse.Status == 0)
                {                        
                    Residue.getInstance().Key = residueResponse.Key;
                    var ackRequest = RequestBuilder.BuildAckRequest();
                    var encryptedRequest = ResidueUtils.Encrypt(ackRequest, Residue.getInstance().Key);
                    writer.WriteLine(encryptedRequest);
                    response = reader.ReadLine();
                    Console.WriteLine("Client response [" + response + "]");
                }
            }
        }
