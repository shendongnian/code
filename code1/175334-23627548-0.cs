    using System;
    
    
    namespace MyElmahReplacement
    {
    
    
    	public class MyVersionInfo
    	{
    
    
    		[System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
    		private static extern IntPtr GetModuleHandle(string strModuleName);
    
    		[System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
    		private static extern int GetModuleFileName(IntPtr ptrHmodule, System.Text.StringBuilder strFileName, int szeSize);
    
    
    
    		private static string GetFileNameFromLoadedModule(string strModuleName)
    		{
    			IntPtr hModule = GetModuleHandle(strModuleName);
    			if (hModule == IntPtr.Zero)
    			{
    				return null;
    			}
    
    			System.Text.StringBuilder sb = new System.Text.StringBuilder(256);
    
    			if (GetModuleFileName(hModule, sb, 256) == 0)
    			{
    				return null;
    			}
    
    			string strRetVal = sb.ToString();
    			if (strRetVal != null && strRetVal.StartsWith("\\\\?\\"))
    				strRetVal = strRetVal.Substring(4);
    			
    			sb.Length = 0;
    			sb = null;
    
    			return strRetVal;
    		}
    
    
    		private static string GetVersionFromFile(string strFilename)
    		{
    			string strRetVal = null;
    
    			try
    			{
    				System.Diagnostics.FileVersionInfo fviVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(strFilename);
    				strRetVal = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}.{1}.{2}.{3}", new object[] {
    					fviVersion.FileMajorPart,
    					fviVersion.FileMinorPart,
    					fviVersion.FileBuildPart,
    					fviVersion.FilePrivatePart
    				});
    			}
    			catch
    			{
    				strRetVal = "";
    			}
    
    			return strRetVal;
    		}
    
    
    		private static string GetVersionOfLoadedModule(string strModuleName)
    		{
    			string strFileNameOfLoadedModule = GetFileNameFromLoadedModule(strModuleName);
    
    			if (strFileNameOfLoadedModule == null)
    				return null;
    
    			return GetVersionFromFile(strFileNameOfLoadedModule);
    		}
    
    
    		public static string SystemWebVersion
    		{
    			get
    			{
    				return GetVersionFromFile(typeof(System.Web.HttpRuntime).Module.FullyQualifiedName);
    			}
    		}
    
    
    		public static bool IsMono
    		{
    			get
    			{
    				return Type.GetType("Mono.Runtime") != null;
    			}
    		}
    
    
    		public static string MonoVersion
    		{
    			get
    			{
    				string strMonoVersion = "";
    
    				Type tMonoRuntime = Type.GetType("Mono.Runtime");
    				if (tMonoRuntime != null)
    				{
    					System.Reflection.MethodInfo displayName = tMonoRuntime.GetMethod("GetDisplayName", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
    					if (displayName != null)
    						strMonoVersion = (string)displayName.Invoke(null, null);
    				}
    
    				return strMonoVersion;
    			}
    		}
    
    
    		public static string DotNetFrameworkVersion
    		{
    			get
    			{
    				// values.Add(ExceptionPageTemplate.Template_RuntimeVersionInformationName, RuntimeHelpers.MonoVersion);
    				if (IsMono)
    					return MonoVersion;
    				
    				// Return System.Environment.Version.ToString()
    				return GetVersionOfLoadedModule("mscorwks.dll");
    			}
    		}
    
    
    		public static string AspNetVersion
    		{
    			get
    			{
    				//values.Add(ExceptionPageTemplate.Template_AspNetVersionInformationName, Environment.Version.ToString());
    				if (IsMono)
    					return System.Environment.Version.ToString();
    				
    				return GetVersionOfLoadedModule("webengine.dll");
    			}
    		}
    
    
    		public static bool IsVistaOrHigher
    		{
    			get
    			{
    				System.OperatingSystem osWindowsVersion = System.Environment.OSVersion;
    				return osWindowsVersion.Platform == System.PlatformID.Win32NT && osWindowsVersion.Version.Major >= 6;
    			}
    		}
    
    
    		public static void Test()
    		{
    			string ErrorPageInfo = 
    				string.Format("Version Information: Microsoft .NET Framework Version: {0}; ASP.NET Version: {1}"
    					,DotNetFrameworkVersion
    					,AspNetVersion
    			);
    
    			Console.WriteLine(ErrorPageInfo);
    		}
    
    
    	} // End Class MyVersionInfo
    
    
    } // End Namespace LegendenTest
