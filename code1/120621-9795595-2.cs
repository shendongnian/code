    /// <summary>
    /// A static class to help with resolving a mapped drive path to a UNC network path.
    /// If a local drive path or a UNC network path are passed in, they will just be returned.
    /// </summary>
    /// <example>
    ///	using System;
    ///	using System.IO;
    ///	using System.Management;    // Reference System.Management.dll
    ///	
    ///	// Example/Test paths, these will need to be adjusted to match your environment. 
    ///	string[] paths = new string[] {
    ///		@"Z:\ShareName\Sub-Folder",
    ///		@"\\ACME-FILE\ShareName\Sub-Folder",
    ///		@"\\ACME.COM\ShareName\Sub-Folder", // DFS
    ///		@"C:\Temp",
    ///		@"\\localhost\c$\temp",
    ///		@"\\workstation\Temp",
    ///		@"Z:", // Mapped drive pointing to \\workstation\Temp
    ///		@"C:\",
    ///		@"Temp",
    ///		@".\Temp",
    ///		@"..\Temp",
    ///		"",
    ///		"    ",
    ///		null
    ///	};
    ///	
    ///	foreach (var curPath in paths) {
    ///		try {
    ///			Console.WriteLine(string.Format("{0} = {1}",
    ///				curPath,
    ///				MappedDriveResolver.ResolveToUNC(curPath))
    ///			);
    ///		}
    ///		catch (Exception ex) {
    ///			Console.WriteLine(string.Format("{0} = {1}",
    ///				curPath,
    ///				ex.Message)
    ///			);
    ///		}
    ///	}
    /// </example>
    public static class MappedDriveResolver
    {
    	/// <summary>
    	/// Resolves the given path to a full UNC path if the path is a mapped drive.
    	/// Otherwise, just returns the given path.
    	/// </summary>
    	/// <param name="path">The path to resolve.</param>
    	/// <returns></returns>
    	public static string ResolveToUNC(string path) {
    		if (String.IsNullOrWhiteSpace(path)) {
    			throw new ArgumentNullException("The path argument was null or whitespace.");
    		}
    
    		if (!Path.IsPathRooted(path)) {
    			throw new ArgumentException(
    				string.Format("The path '{0}' was not a rooted path and ResolveToUNC does not support relative paths.",
    					path)
    			);
    		}
    
    		// Is the path already in the UNC format?
    		if (path.StartsWith(@"\\")) {
    			return path;
    		}
    
    		string rootPath = ResolveToRootUNC(path);
    
    		if (path.StartsWith(rootPath)) {
    			return path; // Local drive, no resolving occurred
    		}
    		else {
    			return path.Replace(GetDriveLetter(path), rootPath);
    		}
    	}
    
    	/// <summary>
    	/// Resolves the given path to a root UNC path if the path is a mapped drive.
    	/// Otherwise, just returns the given path.
    	/// </summary>
    	/// <param name="path">The path to resolve.</param>
    	/// <returns></returns>
    	public static string ResolveToRootUNC(string path) {
    		if (String.IsNullOrWhiteSpace(path)) {
    			throw new ArgumentNullException("The path argument was null or whitespace.");
    		}
    
    		if (!Path.IsPathRooted(path)) {
    			throw new ArgumentException(
    				string.Format("The path '{0}' was not a rooted path and ResolveToRootUNC does not support relative paths.",
    				path)
    			);
    		}
    
    		if (path.StartsWith(@"\\")) {
    			return Directory.GetDirectoryRoot(path);
    		}
    
    		// Get just the drive letter for WMI call
    		string driveletter = GetDriveLetter(path);
    
    		// Query WMI if the drive letter is a network drive, and if so the UNC path for it
    		using (ManagementObject mo = new ManagementObject()) {
    			mo.Path = new ManagementPath(string.Format("Win32_LogicalDisk='{0}'", driveletter));
    
    			DriveType driveType = (DriveType)((uint)mo["DriveType"]);
    			string networkRoot = Convert.ToString(mo["ProviderName"]);
    
    			if (driveType == DriveType.Network) {
    				return networkRoot;
    			}
    			else {
    				return driveletter + Path.DirectorySeparatorChar;
    			}
    		}			
    	}
    
    	/// <summary>
    	/// Checks if the given path is a network drive.
    	/// </summary>
    	/// <param name="path">The path to check.</param>
    	/// <returns></returns>
    	public static bool isNetworkDrive(string path) {
    		if (String.IsNullOrWhiteSpace(path)) {
    			throw new ArgumentNullException("The path argument was null or whitespace.");
    		}
    
    		if (!Path.IsPathRooted(path)) {
    			throw new ArgumentException(
    				string.Format("The path '{0}' was not a rooted path and ResolveToRootUNC does not support relative paths.",
    				path)
    			);
    		}
    
    		if (path.StartsWith(@"\\")) {
    			return true;
    		}
    
    		// Get just the drive letter for WMI call
    		string driveletter = GetDriveLetter(path);
    
    		// Query WMI if the drive letter is a network drive
    		using (ManagementObject mo = new ManagementObject()) {
    			mo.Path = new ManagementPath(string.Format("Win32_LogicalDisk='{0}'", driveletter));
    			DriveType driveType = (DriveType)((uint)mo["DriveType"]);
    			return driveType == DriveType.Network;
    		}
    	}
    
    	/// <summary>
    	/// Given a path will extract just the drive letter with volume separator.
    	/// </summary>
    	/// <param name="path"></param>
    	/// <returns>C:</returns>
    	public static string GetDriveLetter(string path) {
    		if (String.IsNullOrWhiteSpace(path)) {
    			throw new ArgumentNullException("The path argument was null or whitespace.");
    		}
    
    		if (!Path.IsPathRooted(path)) {
    			throw new ArgumentException(
    				string.Format("The path '{0}' was not a rooted path and GetDriveLetter does not support relative paths.",
    				path)
    			);
    		}
    
    		if (path.StartsWith(@"\\")) {
    			throw new ArgumentException("A UNC path was passed to GetDriveLetter");
    		}
    
    		return Directory.GetDirectoryRoot(path).Replace(Path.DirectorySeparatorChar.ToString(), "");
    	}
    }
