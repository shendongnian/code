                // Create a channel factory.
                NetTcpBinding b = new NetTcpBinding();
                b.Security.Mode = SecurityMode.Transport;
                b.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
                b.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
                b.MaxReceivedMessageSize = 1000000;
                b.OpenTimeout = TimeSpan.FromMinutes(2);
                b.SendTimeout = TimeSpan.FromMinutes(2);
                b.ReceiveTimeout = TimeSpan.FromMinutes(10);
