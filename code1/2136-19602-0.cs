        public static string GetServerName()
        {
            string serverName = "Unknown";
            
            Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ServiceModelSectionGroup serviceModel = ServiceModelSectionGroup.GetSectionGroup(appConfig);
            BindingsSection bindings = serviceModel.Bindings;
            ChannelEndpointElementCollection endpoints = serviceModel.Client.Endpoints;
            for(int i=0; i<endpoints.Count; i++)
            {
                ChannelEndpointElement endpointElement = endpoints[i];
                if (endpointElement.Contract == "MyContractName")
                {
                    serverName = endpointElement.Address.Host;
                }
            }
            return serverName;
        }
