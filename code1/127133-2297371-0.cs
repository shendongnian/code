    string[] files;
    string[] folders;
    WindowsIdentity id = (WindowsIdentity)User.Identity;
    using (System.Security.Principal.WindowsImpersonationContext context = id.Impersonate())
    {
    	files = Directory.GetFiles(RootDir);
    	folders = Directory.GetDirectories(RootDir);
    
    	foreach (string file in files)
    	{
    		FileInfo fi = new FileInfo(file);
    		FileSecurity fs = null;
    		try
    		{
    			fs = fi.GetAccessControl(AccessControlSections.Access);
    		}
    		catch (UnauthorizedAccessException)
    		{
    			goto Next;
    		}
    		foreach (FileSystemAccessRule rule in fs.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier)))
    		{
    			if (id.User.CompareTo(rule.IdentityReference as SecurityIdentifier) == 0)
    			{
    				if(rule.AccessControlType.ToString() == "Deny" &&
    					rule.FileSystemRights.ToString().Contains("ReadData"))
    				{
    					goto Next;
    				}
    			}
    		}
    
    		Response.Write(file + " " + fi.Length + "<br />");
    		// next in sequence. label for goto
    		Next: ;
    	}
    	context.Undo();
    }
