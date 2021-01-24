    static void Main(string[] args)
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDeviceCollection collection = enumerator.EnumAudioEndpoints(DataFlow.Render,DeviceState.Active);
            Console.WriteLine($"\nNumber of active Devices: {collection.GetCount()}");
            int i = 0;
            foreach (MMDevice device in collection){
                Console.WriteLine($"\n{i} Friendly name: {device.FriendlyName}");
                Console.WriteLine($"Endpoint ID: {device.DeviceID}");
                i++;
            }
            Console.ReadKey();
        }
