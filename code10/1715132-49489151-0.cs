    class Program
    {
        static void Main(string[] args)
        {
            MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
            MMDeviceCollection devices = DevEnum.EnumerateAudioEndPoints(EDataFlow.eCapture, EDeviceState.DEVICE_STATE_ACTIVE);
            MMDevice DefaultDevice = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eMultimedia);
            MMDevice SecondaryDevice = null;
            PolicyConfigClient client = new PolicyConfigClient();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("List of sound cards installed");
            Console.WriteLine("-----------------------------------");
            for (int i = 0; i < devices.Count; i++)
            { 
                if (devices[i].ID != DefaultDevice.ID)
                {
                    SecondaryDevice = devices[i];
                }
                Console.WriteLine(devices[i].FriendlyName);
                Console.ReadLine();
            }
            Console.WriteLine("Default Device");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(DefaultDevice.FriendlyName);
            Console.ReadLine();
            Console.WriteLine("Secondary Device");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(SecondaryDevice.FriendlyName);
            Console.ReadLine();
            client.SetDefaultEndpoint(SecondaryDevice.ID, ERole.eCommunications);
            client.SetDefaultEndpoint(SecondaryDevice.ID, ERole.eMultimedia);
            client.SetDefaultEndpoint(SecondaryDevice.ID, ERole.eConsole);
            DefaultDevice = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eMultimedia);
            Console.WriteLine("New Default Device");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(DefaultDevice.FriendlyName);
            Console.ReadLine();
        }
    }
