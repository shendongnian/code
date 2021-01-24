    public interface IBluetoothCommFactory { }
    public interface IWifiCommFactory { }
    /// <summary>
    /// This is our base factory
    /// </summary>
    public interface ICommunicationBaseFactory
    {
        IBluetoothCommFactory InitializeBluetoothCommunication();
        IWifiCommFactory InitializeWiFiCommnucation();
    }
    public class BluetoothCommunication : IBluetoothCommFactory
    {
        public BluetoothCommunication()
        {
            // Implement some init logic here...
            Console.WriteLine("Bluetooth Communication was initialized");
         }
    }
    public class WiFiCommunication : IWifiCommFactory
    {
        public WiFiCommunication()
        {
            // Implement some init logic here...
            Console.WriteLine("WIFI (generic) Communication was initialized");
        }
    }
