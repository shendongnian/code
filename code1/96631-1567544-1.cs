		void Installer1_AfterInstall(object sender, InstallEventArgs e)
		{
			string myAssembly = Path.GetFullPath(this.Context.Parameters["assemblypath"]);
			string logPath = Path.Combine(Path.GetDirectoryName(myAssembly), "Logs");
			Directory.CreateDirectory(logPath);
			ReplacePermissions(logPath, WellKnownSidType.NetworkServiceSid, FileSystemRights.FullControl);
		}
		static void ReplacePermissions(string filepath, WellKnownSidType sidType, FileSystemRights allow)
		{
			FileSecurity sec = File.GetAccessControl(filepath);
			SecurityIdentifier sid = new SecurityIdentifier(sidType, null);
			sec.PurgeAccessRules(sid); //remove existing
			sec.AddAccessRule(new FileSystemAccessRule(sid, allow, AccessControlType.Allow));
			File.SetAccessControl(filepath, sec);
		}
