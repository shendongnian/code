    //Paired bluetooth devices
    DeviceInformationCollection PairedBluetoothDevices =
           await DeviceInformation.FindAllAsync(BluetoothDevice.GetDeviceSelectorFromPairingState(true));
    //Connected bluetooth devices
    DeviceInformationCollection ConnectedBluetoothDevices =
           await DeviceInformation.FindAllAsync(BluetoothDevice.GetDeviceSelectorFromConnectionStatus(BluetoothConnectionStatus.Connected));
