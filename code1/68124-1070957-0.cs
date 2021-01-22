            MSTSCLib6.IMsRdpClient6 client6 = RdpClient.GetOcx() as MSTSCLib6.IMsRdpClient6;            
            if (client6 != null)
            {
                MSTSCLib6.IMsRdpClientTransportSettings2 transport = client6.TransportSettings2;
                if (Convert.ToBoolean(transport.GatewayIsSupported) == true)
                {
                    client6.TransportSettings.GatewayHostname = "mygateway";
                    client6.TransportSettings.GatewayUsageMethod = 1;
                    client6.TransportSettings.GatewayCredsSource = 0;
                    client6.TransportSettings.GatewayProfileUsageMethod = 1;
                    client6.TransportSettings2.GatewayDomain = "mydomain";
                    client6.TransportSettings2.GatewayPassword = "mypassword";
                    client6.TransportSettings2.GatewayUsername = "myusername";
                }
            }
