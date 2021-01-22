            System.Net.Sockets.TcpClient TC = new System.Net.Sockets.TcpClient();
            TC.Connect("mail.google.com", 443);
            using (System.Net.Security.SslStream Ssl = new System.Net.Security.SslStream(TC.GetStream()))
            {
                Ssl.AuthenticateAsClient("mail.google.com");
                Console.WriteLine(Ssl.CipherAlgorithm);
                Console.WriteLine(Ssl.CipherStrength);
            }
            TC.Close();
