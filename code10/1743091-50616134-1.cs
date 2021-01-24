     public void Authenticate()
            {
                var monitorClient = new MonitorManagementClient(new CustomCredentials()) { SubscriptionId = "subscription Id" };
                MonitorClient = monitorClient;
            }
