    public class ProductPrototypeONE : ICommunicationBaseFactory
    {
        public IBluetoothCommFactory InitializeBluetoothCommunication()
        {
            return new BluetoothCommunication();
        }
        public IWifiCommFactory InitializeWiFiCommnucation()
        {
            return new WiFiCommunication();
        }
    }
