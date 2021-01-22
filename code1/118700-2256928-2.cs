        static string GetClientIP()
        {
            var context = OperationContext.Current;
            var mp = context.IncomingMessageProperties;
            var propName = RemoteEndpointMessageProperty.Name;
            var prop = (RemoteEndpointMessageProperty) mp[propName];
            string remoteIP = prop.Address;
            
            if(remoteIP.IndexOf(":") < 0)
            {
                IPAddress[] addresses = Dns.GetHostAddresses(remoteIP);
                for (int i = 0; i < addresses.Length; i++)
                {
                    if(addresses[i].ToString().IndexOf(".")>-1)
                        return addresses[i].ToString();
                }
                return remoteIP;
            }
            else
            {
                return remoteIP;
            }
        }
