    	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.IO;
	using System.Security.Permissions;
	using System.Security.Principal;
	using System.Security.AccessControl;
	namespace GrantingFilePermsTests
	{
	    class Program
	    {
		static void Main(string[] args)
		{
		    string strFilePath1 = "E:/1.txt";
		    string strFilePath2 = "E:/2.txt";
		    if (File.Exists(strFilePath1))
		    {
			File.Delete(strFilePath1);
		    }
		    if (File.Exists(strFilePath2))
		    {
			File.Delete(strFilePath2);
		    }
		    File.Create(strFilePath1);
		    File.Create(strFilePath2);
		    // Get a FileSecurity object that represents the
		    // current security settings.
		    FileSecurity fSecurity = File.GetAccessControl(strFilePath1);
		    // Add the FileSystemAccessRule to the security settings.
		    fSecurity.AddAccessRule(new FileSystemAccessRule("IUSR_SOMESERVER",FileSystemRights.FullControl,AccessControlType.Allow));
		    // Set the new access settings.
		    File.SetAccessControl(strFilePath1, fSecurity);
		    }
	    }
	}
