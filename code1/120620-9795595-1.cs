    using System;
    using System.IO;
    using System.Management;    // System.Management.dll
		public class MappedDriveResolver {
			/// <summary>Resolves the given path to a full UNC path, or full local drive path.</summary>
			/// <param name="pPath"></param>
			/// <returns></returns>
			public string ResolveToUNC(string pPath) {
				if (pPath.StartsWith(@"\\")) { return pPath; }
				string root = ResolveToRootUNC(pPath);
				if (pPath.StartsWith(root)) {
					return pPath; // Local drive, no resolving occurred
				} else {
					return pPath.Replace(GetDriveLetter(pPath), root);
				}
			}
			/// <summary>Resolves the given path to a root UNC path, or root local drive path.</summary>
			/// <param name="pPath"></param>
			/// <returns>\\server\share OR C:\</returns>
			public string ResolveToRootUNC(string pPath) {
				ManagementObject mo = new ManagementObject();
				if (pPath.StartsWith(@"\\")) { return Directory.GetDirectoryRoot(pPath); }
				// Get just the drive letter for WMI call
				string driveletter = GetDriveLetter(pPath);
				mo.Path = new ManagementPath(string.Format("Win32_LogicalDisk='{0}'", driveletter));
				// Get the data we need
				uint DriveType = Convert.ToUInt32(mo["DriveType"]);
				string NetworkRoot = Convert.ToString(mo["ProviderName"]);
				mo = null;
				// Return the root UNC path if network drive, otherwise return the root path to the local drive
				if (DriveType == 4) {
					return NetworkRoot;
				} else {
					return driveletter + Path.DirectorySeparatorChar;
				}
			}
			/// <summary>Checks if the given path is on a network drive.</summary>
			/// <param name="pPath"></param>
			/// <returns></returns>
			public bool isNetworkDrive(string pPath) {
				ManagementObject mo = new ManagementObject();
				if (pPath.StartsWith(@"\\")) { return true; }
				// Get just the drive letter for WMI call
				string driveletter = GetDriveLetter(pPath);
				mo.Path = new ManagementPath(string.Format("Win32_LogicalDisk='{0}'", driveletter));
				// Get the data we need
				uint DriveType = Convert.ToUInt32(mo["DriveType"]);
				mo = null;
				return DriveType == 4;
			}
			/// <summary>Given a path will extract just the drive letter with volume separator.</summary>
			/// <param name="pPath"></param>
			/// <returns>C:</returns>
			public string GetDriveLetter(string pPath) {
				if (pPath.StartsWith(@"\\")) { throw new ArgumentException("A UNC path was passed to GetDriveLetter"); }
				return Directory.GetDirectoryRoot(pPath).Replace(Path.DirectorySeparatorChar.ToString(), "");
			}
		}
