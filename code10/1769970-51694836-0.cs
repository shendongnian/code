     private static RegistryManager registryManager;
        private static string iotHubConnectionString = "<YOUR IOT HUB CONNECTION STRING";
        static void Main(string[] args)
        {
            MainAsync();
            Console.ReadLine();
        }
        static async void MainAsync()
        {
            registryManager = RegistryManager.CreateFromConnectionString(iotHubConnectionString);
            var queryResult = registryManager.CreateQuery("SELECT * FROM devices");
            while (queryResult.HasMoreResults)
            {
                var page = await queryResult.GetNextAsTwinAsync();
                foreach (var twin in page)
                {
                    Console.WriteLine("The last activity time of the device {0} is {1}", twin.DeviceId, twin.LastActivityTime);
                }
            }
        }
