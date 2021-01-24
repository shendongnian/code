    var deviceDefinition = new SsdpRootDevice()
    {
    	CacheLifetime = TimeSpan.FromMinutes(30), //How long SSDP clients can cache this info.
    	Location = new Uri("http://mydevice/descriptiondocument.xml"), // Must point to the URL that serves your devices UPnP description document. 
    	DeviceTypeNamespace = "my-namespace",
    	DeviceType = "MyCustomDevice",
    	FriendlyName = "Custom Device 1",
    	Manufacturer = "Me",
    	ModelName = "MyCustomDevice",
    	Uuid = GetPersistentUuid() // This must be a globally unique value that survives reboots etc. Get from storage or embedded hardware etc.
    };
