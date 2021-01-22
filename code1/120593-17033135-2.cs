            X509Certificate2 Cert = new X509Certificate2("client.p12", "1234", X509KeyStorageFlags.MachineKeySet);
            // Create a new WebClient instance.
            CertificateWebClient myWebClient = new CertificateWebClient(Cert);
            string fileName = Installation.destXML;
            string uriString = "https://xxxxxxx.xx:918";
            // Upload the file to the URI.
            // The 'UploadFile(uriString,fileName)' method implicitly uses HTTP POST method.
            byte[] responseArray = myWebClient.UploadFile(uriString, fileName);
            // Decode and display the response.
            Console.WriteLine("\nResponse Received.The contents of the file uploaded are:\n{0}",
                System.Text.Encoding.ASCII.GetString(responseArray));
