     private static  IReadOnlyList<GattDeviceService>GetGattServicesAsync(BluetoothLEDevice device, bool useUnCachedServices)
        {
          var CancellationTokenSource = new CancellationTokenSource();
          var CancellationToken = new CancellationTokenSource.Token;
            var GetResults = task.Run(async ()=> awite useUnCachedServices ? device.GetGattServicesAsync(BluetoothCacheMode.Uncached).GetResults() : device.GetGattServicesAsync().GetResults(),_cancellationToken);
            
            WaitHandle.WaitAny(new[] { cancellationTokenSource.Token.WaitHandle }, TimeSpan.Fromseconds(10));
         
            Global.Log.TraceOut();
            // Return list anyway
            return services.Services;
        }
