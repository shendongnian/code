	public static void ChangeServiceMode(bool serviceAutoEnable)
        {
			RegistryKey key     = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\NixService", true);
            if (key != null)
            {
                //Set service to manual / Automatic (Automatic = 2, manual = 3)
                int serviceMode = serviceAutoEnable ? 2 : 3;
                key.SetValue("Start", serviceMode, RegistryValueKind.DWord);
                key.Close();
            }
		}
	}
	
