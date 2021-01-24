    public static void StartSingleProcess(string port)
        {
            Process p = Process.Start(Containers.Path.location, port);
            NetTcpBinding binding = new NetTcpBinding();
            binding.OpenTimeout = new TimeSpan(0, 10, 0);
            binding.CloseTimeout = new TimeSpan(0, 10, 0);
            binding.SendTimeout = new TimeSpan(0, 10, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
            ChannelFactory<IContainer> factory = new ChannelFactory<IContainer>(binding, new EndpointAddress($"net.tcp://localhost:{port}/IContainer")); // moraju se cuvati proxiji zbog poziva metode load n puta 
            proxies.Add(factory.CreateChannel());
            OriginalprocessesIDs.Add(p, port);
        }
