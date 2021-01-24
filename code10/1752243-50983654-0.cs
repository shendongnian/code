    private libraryOpenInterface _libraryOI1;
	private IEnumrable<DeviceCredentialsModel>  getDevicesCredentials()
	{
		#get from db of configuration
	}
	void connectToAllDevices()
	{
		var devices = getDevicesCredentials();
		foreach(device in devices)
		{
			var encryptedPassword = device.password;
			var decryptedPassword = ...decrypt;
			_libraryOI1.connect(device.ip, v.user, decryptedPassword);
		}
	}
