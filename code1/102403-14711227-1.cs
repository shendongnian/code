    /// <summary>
	/// To read a registry key.
	/// input: KeyName (string)
	/// output: value (string) 
	/// </summary>
	public string Read(string KeyName)
	{
		// Opening the registry key
		RegistryKey rk = baseRegistryKey ;
		// Open a subKey as read-only
		RegistryKey sk1 = rk.OpenSubKey(subKey);
		// If the RegistrySubKey doesn't exist -> (null)
		if ( sk1 == null )
		{
			return null;
		}
		else
		{
			try 
			{
				// If the RegistryKey exists I get its value
				// or null is returned.
				return (string)sk1.GetValue(KeyName.ToUpper());
			}
			catch (Exception e)
			{
				// AAAAAAAAAAARGH, an error!
				ShowErrorMessage(e, "Reading registry " + KeyName.ToUpper());
				return null;
			}
		}
	}
