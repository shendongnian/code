    public class BluetoothLowEnergyCommunication : IBluetoothCommFactory
    {
        public BluetoothLowEnergyCommunication()
        {
            // Implement some init logic here...
            Console.WriteLine("Bluetooth Low Energy Communication was initialized");
        }
    }
    public class WiFiLowBandCommunication : IWifiCommFactory
    {
        public WiFiLowBandCommunication()
        {
            // Implement some init logic here...
            Console.WriteLine("WIFI Low Band Communication was initialized");
        }
    }
    public class WifiHighBandCommunication : IWifiCommFactory
    {
        public WifiHighBandCommunication()
        {
            // Implement some init logic here...
            Console.WriteLine("WIFI High Band Communication was initialized");
        }
    }
