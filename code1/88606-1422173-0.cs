    RegistryKey myKey = Registry.LocalMachine.OpenSubKey( "SYSTEM\\CurrentControlSet\\Enum\\IDE\\" );
	foreach( string driveManafacturer in myKey.GetSubKeyNames() )
	{
		RegistryKey driveKey = myKey.OpenSubKey( driveManafacturer );
		foreach( string driveID in driveKey.GetSubKeyNames() )
		{
			RegistryKey subKey = driveKey.OpenSubKey( driveID );
			string driveType = (string)subKey.GetValue( "Class" );
			if( driveType == "DiskDrive" )
			{
				RegistryKey tempKey = subKey.OpenSubKey( "Device Parameters", true );
				RegistryKey tempKey2 = tempKey.OpenSubKey( "Disk" );
				if( tempKey2 == null )
				{
					tempKey2 = tempKey.CreateSubKey( "Disk" );
					tempKey2.SetValue( "UserWriteCacheSetting", 0x0 );
				}
			}
		}
	}
