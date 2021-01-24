    Parallel.ForEach(devices, (device) =>
                {
                            // register device into IoT hub 
                            Device device;
                RegistryManager registryManager = RegistryManager.CreateFromConnectionString("connectionString");
                            device = await registryManager.AddDeviceAsync(new Device(deviceId));
    
    
                            // send message to iot hub
                             DeviceClient deviceClient;
                            await deviceClient.SendEventAsync("data");                       
    
                });
