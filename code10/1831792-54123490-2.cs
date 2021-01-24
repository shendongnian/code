    if(newState == ProfileState.Connected)
    {
        IsDisconnected = false; //notice change true -> false
        gatt.DiscoverServices();
    }
    else if(newState == ProfileState.Disconnected)
    {
        gatt.Close();
        IsDisconnected = true;
        Log.Info("BLE", "Status: Disconnected");
    }
