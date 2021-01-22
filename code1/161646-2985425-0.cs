		private readonly static WindowsIdentity _identity = WindowsIdentity.GetCurrent();
		protected static bool GetPermission(FileSystemRights right, string path)
		{
			FileSecurity fs;
			try
			{
				fs = System.IO.File.GetAccessControl(path);
			}
			catch(InvalidOperationException)
			{
				// called on a disk that's not present, ...
				return false;
			}
			catch(UnauthorizedAccessException)
			{
				return false;
			}
			foreach(FileSystemAccessRule fsar in fs.GetAccessRules(true, true, typeof(SecurityIdentifier)))
			{
				if(fsar.IdentityReference == _identity.User && fsar.FileSystemRights.HasFlag(right) && fsar.AccessControlType == AccessControlType.Allow)
				{
					return true;
				}
				else if(_identity.Groups.Contains(fsar.IdentityReference) && fsar.FileSystemRights.HasFlag(right) && fsar.AccessControlType == AccessControlType.Allow)
				{
					return true;
				}
			}
			return false;
		}
