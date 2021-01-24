    public enum BluetoothType
    {
        CLASSIC_TYPE,
        BLE_TYPE
    }
    public enum WiFiType
    {
        LOW_BAND,
        HIGH_BAND
    }
    public class ProductPrototypeTWO : ICommunicationBaseFactory
    {
        private BluetoothType _bluetoothType;
        private WiFiType _wifiType;
        public ProductPrototypeTWO(BluetoothType bluetoothType, WiFiType wifiType)
        {
            _bluetoothType = bluetoothType;
            _wifiType = wifiType;
        }
        public IBluetoothCommFactory InitializeBluetoothCommunication()
        {
            switch (_bluetoothType)
            {
                case BluetoothType.CLASSIC_TYPE:
                    return new BluetoothCommunication();
                case BluetoothType.BLE_TYPE:
                    return new BluetoothLowEnergyCommunication();
                default:
                    throw new NotSupportedException("Unknown Bluetooth type");
            }
        }
        public IWifiCommFactory InitializeWiFiCommnucation()
        {
            switch (_wifiType)
            {
                case WiFiType.LOW_BAND:
                    return new WiFiLowBandCommunication();
                case WiFiType.HIGH_BAND:
                    return new WifiHighBandCommunication();
                default:
                    throw new NotSupportedException("Unknown WIFI type");
            }
        }
    }
