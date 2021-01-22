    RegistrySecurity rs = new RegistrySecurity();
			
    rs.AddAccessRule(new RegistryAccessRule(user,
				RegistryRights.FullControl,
				InheritanceFlags.ObjectInherit,
				PropagationFlags.InheritOnly,
				AccessControlType.Allow));
	RegistryKey subKey = registryKey.OpenSubKey(guid) ??    registryKey.CreateSubKey(guid, RegistryKeyPermissionCheck.Default, rs);
