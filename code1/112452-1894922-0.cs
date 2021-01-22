    class NatTest
    {
        public Start ()
        {
            // Hook into the events so you know when a router
            // has been detected or has gone offline
            NatUtility.DeviceFound += DeviceFound;
            NatUtility.DeviceLost += DeviceLost;
            // Start searching for upnp enabled routers
            NatUtility.StartDiscovery ();
        }
        void DeviceFound(object sender, DeviceEventArgs args)
        {
            // This is the upnp enabled router
            INatDevice device = args.Device;
            // Create a mapping to forward external port 3000 to local port 1500
            device.CreatePortMap(new Mapping(Protocol.Tcp, 1500, 3000));
            // Retrieve the details for the port map for external port 3000
            Mapping m = device.GetSpecificMapping(Protocol.Tcp, 3000);
            // Get all the port mappings on the device and delete them
            foreach (Mapping mp in device.GetAllMappings())
                device.DeletePortMap(mp);
            // Get the external IP address
            IPAddress externalIP = device.GetExternalIP();
        }
        private void DeviceLost (object sender, DeviceEventArgs args)
        {
            INatDevice device = args.Device;
            Console.WriteLine ("Device Lost");
            Console.WriteLine ("Type: {0}", device.GetType().Name);
        }
    }
