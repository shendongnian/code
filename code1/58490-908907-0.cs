    string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
    using(Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
    {
    	foreach(string subkey_name in key.GetSubKeyNames())
    	{
    		using(RegistryKey subkey = key.OpenSubKey(subkey_name))
    		{
    			Console.WriteLine(subkey.GetValue("DisplayName"));
    		}
    	}
    }
