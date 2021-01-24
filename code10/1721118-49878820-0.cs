    _watcher = new BluetoothLEAdvertisementWatcher();
    _watcher.ScanningMode = BluetoothLEScanningMode.Active;
    _watcher.SignalStrengthFilter = new BluetoothSignalStrengthFilter
                                        {
                                             InRangeThresholdInDBm = -75,
                                             OutOfRangeThresholdInDBm = -76,
                                             OutOfRangeTimeout	= TimeSpan.FromSeconds(2),
                                             SamplingInterval = TimeSpan.FromSeconds(2)
                                        };
    _watcher.AdvertisementFilter =
         new BluetoothLEAdvertisementFilter
             {
                  Advertisement =
                      new BluetoothLEAdvertisement
                          {
                                ServiceUuids =
                                    {
                                            BLEHelper.ServiceId
                                    }
                           }
            };
    _watcher.Received += OnWatcherOnReceived;
    _watcher.Start();
