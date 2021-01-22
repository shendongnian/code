    private bool checkPortIsOpen(string portNumer)
        {
            ServerManager serverMgr = new ServerManager();
            int index = 0;
            bool isOpen = true;
            foreach (Site mySite in serverMgr.Sites)
            {
                foreach (Microsoft.Web.Administration.ConfigurationElement binding in mySite.GetCollection("bindings"))
                {
                    string protocol = (string)binding["protocol"];
                    string bindingInfo = (string)binding["bindingInformation"];
                    if (protocol.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        string[] parts = bindingInfo.Split(':');
                        if (parts.Length == 3)
                        {
                            string port = parts[1];
                            if(port.Equals(portNumer.ToString()))
                            {
                                isOpen = false;
                                webSite_portInUse = mySite.Name;
                            }
                        }
                    }
                    index++;
                }
            }
            return isOpen;
        }
