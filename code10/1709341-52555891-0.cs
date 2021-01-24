    // Create a device watcher to look for instances of the Xerox device
    watcher = DeviceInformation.CreateWatcher(UsbDevice.GetDeviceSelector(vendorId, productId));
    watcher.Added += new TypedEventHandler<DeviceWatcher, DeviceInformation>(this.OnDeviceAdded);
    watcher.Removed += new TypedEventHandler<DeviceWatcher, DeviceInformationUpdate>(this.OnDeviceRemoved);
    watcher.EnumerationCompleted += new TypedEventHandler<DeviceWatcher, Object>(this.OnDeviceEnumerationComplete);
    watcher.Start();
