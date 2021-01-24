	private Dictionary<DeviceConnectionTypeEnum, IConnector> m_DeviceConnectorToType ..... <-you need to populate this dicionary
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
			var deviceConnectionTypeEnum = device.DeviceConnectionTypeEnum;
			IConnector deviceConnector = m_DeviceConnectorToType[deviceConnectionTypeEnum];
					
			deviceConnector.connect(device.ip, v.user, decryptedPassword);
		}
	}
