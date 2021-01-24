    ICommunicationBaseFactory baseFactory = new ProductPrototypeONE();
    baseFactory.InitializeBluetoothCommunication();
    baseFactory.InitializeWiFiCommnucation();
    baseFactory = new ProductPrototypeTWO(BluetoothType.BLE_TYPE, WiFiType.HIGH_BAND);
    baseFactory.InitializeBluetoothCommunication();
    baseFactory.InitializeWiFiCommnucation();
