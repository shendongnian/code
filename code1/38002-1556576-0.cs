		public static void ReplacePermissions(string filepath, WellKnownSidType sidType, FileSystemRights allow)
		{
			FileSecurity sec = File.GetAccessControl(filepath);
			SecurityIdentifier sid = new SecurityIdentifier(sidType, null);
			sec.PurgeAccessRules(sid); //remove existing
			sec.AddAccessRule(new FileSystemAccessRule(sid, allow, AccessControlType.Allow));
			File.SetAccessControl(filepath, sec);
		}
