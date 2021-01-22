            List<IPAddress> ipList = new List<IPAddress>();
            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces()) {
                foreach (var ua in ni.GetIPProperties().UnicastAddresses) {
                    if (ua.Address.AddressFamily == AddressFamily.InterNetwork) {
                        Console.WriteLine("found ip " + ua.Address.ToString());
                        ipList.Add(ua.Address);
                    }
                }
            }
