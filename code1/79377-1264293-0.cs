    using (DirectoryEntry obj = new DirectoryEntry("LDAP://" + dn))
	{
		obj.RefreshCache(new string[] { "tokenGroups" });
		string[] sids = new string[obj.Properties["tokenGroups"].Count];
		int i = 0;
		foreach (byte[] bytes in obj.Properties["tokenGroups"])
		{
			sids[i] = _ConvertSidToString(bytes);
			++i;
		}
		obj.Close();
		return sids;
	}
