    static async Task startClient(string IoTHub, string IoTDevicePrefix, int deviceNumber, string commonKey, int maxMessages, int messageDelaySeconds)
    {
        allClientStarted++;
        runningDevices++;
        string connectionString = "HostName=" + IoTHub + ";DeviceId=" + IoTDevicePrefix + deviceNumber + ";SharedAccessKey=" + commonKey;
        DeviceClient device = DeviceClient.CreateFromConnectionString(connectionString, Microsoft.Azure.Devices.Client.TransportType.Mqtt);
        await device.OpenAsync();
        Random rnd = new Random();
        int mycounter = 1;
        Console.WriteLine("Device " + IoTDevicePrefix + deviceNumber + " started");
    
        while (mycounter <= maxMessages)
        {
            Thread.Sleep((messageDelaySeconds * 1000) + rnd.Next(1, 100));
            string message = "{ \'loadTest\':\'True\', 'sequenceNumber': " + mycounter + ", \'SubmitTime\': \'" + DateTime.UtcNow + "\', \'randomValue\':" + rnd.Next(1, 4096 * 4096) + " }";
            Microsoft.Azure.Devices.Client.Message IoTMessage = new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(message));
            await device.SendEventAsync(IoTMessage);
            totalMessageSent++;
            mycounter++;
        }
        await device.CloseAsync();
        Console.WriteLine("Device " + IoTDevicePrefix + deviceNumber + " ended");
        runningDevices--;
    }
    
    static void createDevices(int number)
    {
        for (int i = 1; i <= number; i++)
        {
            var registryManager = RegistryManager.CreateFromConnectionString(iotHubConnectionString);
            Device mydevice = new Device(IoTDevicePrefix + i.ToString());
            mydevice.Authentication = new AuthenticationMechanism();
            mydevice.Authentication.SymmetricKey.PrimaryKey = commonKey;
            mydevice.Authentication.SymmetricKey.SecondaryKey = commonKey;
            try
            {
                registryManager.AddDeviceAsync(mydevice).Wait();
                Console.WriteLine("Adding device: " + IoTDevicePrefix + i.ToString());
            }
            catch (Exception er)
            {
                Console.WriteLine("  Error adding device: " + IoTDevicePrefix + i.ToString() + " error: " + er.InnerException.Message);
            }
        }
    
    }
        
