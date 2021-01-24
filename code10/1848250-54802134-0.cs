      BluetoothManager bluetoothManager = (BluetoothManager)GetSystemService(Context.BluetoothService);
      BluetoothAdapter mBluetoothAdapter = bluetoothManager.Adapter;                   
          if (!mBluetoothAdapter.IsEnabled)
             {
               Intent enableBtIntent = new Intent(BluetoothAdapter.ActionRequestEnable);
               StartActivityForResult(enableBtIntent, REQUEST_ENABLE_BT);
             }
          else
             {
               mBluetoothAdapter.StartDiscovery();
             }
      protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            // User chose not to enable Bluetooth.
            if (requestCode == REQUEST_ENABLE_BT && resultCode == Result.Canceled)
            {
                Finish();
                return;
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }
