	if (!System.IO.File.Exists(fullPath))
	{
		using (WindowsIdentity.GetCurrent().Impersonate())
		{
			try
			{
				image.Save(fullPath);
				System.Security.AccessControl.DirectorySecurity sec = System.IO.Directory.GetAccessControl(originalDocumentFolderPath);
				FileSystemAccessRule accRule = new FileSystemAccessRule(username, FileSystemRights.FullControl, AccessControlType.Allow);
				sec.AddAccessRule(accRule);
				string sharedFolderPath = "\\\\" + Path.Combine(Environment.MachineName, "Users");
				sharedFolderPath = Path.Combine(sharedFolderPath, username);
				sharedFolderPath = Path.Combine(sharedFolderPath, "Desktop");
				sharedFolderPath = Path.Combine(sharedFolderPath, "SharedFolder");
				sharedFolderPath = Path.Combine(sharedFolderPath, "file.extension");
				System.IO.File.Copy(originalDocumentFolderPath, sharedFolderPath);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
