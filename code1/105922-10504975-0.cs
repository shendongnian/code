        public static System.Reflection.Assembly GetAssembly(string pAssemblyName)
		{
			System.Reflection.Assembly tMyAssembly = null;
			if (string.IsNullOrEmpty(pAssemblyName)) { return tMyAssembly; }
			tMyAssembly = GetAssemblyEmbedded(pAssemblyName);
			if (tMyAssembly == null) { GetAssemblyDLL(pAssemblyName); }
			return tMyAssembly;
		}//System.Reflection.Assembly GetAssemblyEmbedded(string pAssemblyDisplayName)
		public static System.Reflection.Assembly GetAssemblyEmbedded(string pAssemblyDisplayName)
		{
			System.Reflection.Assembly tMyAssembly = null;
			if(string.IsNullOrEmpty(pAssemblyDisplayName)) { return tMyAssembly; }
			try //try #a
			{
				tMyAssembly = System.Reflection.Assembly.Load(pAssemblyDisplayName);
			}// try #a
			catch (Exception ex)
			{
				string m = ex.Message;
			}// try #a
			return tMyAssembly;
		}//System.Reflection.Assembly GetAssemblyEmbedded(string pAssemblyDisplayName)
		public static System.Reflection.Assembly GetAssemblyDLL(string pAssemblyNameDLL)
		{
			System.Reflection.Assembly tMyAssembly = null;
			if (string.IsNullOrEmpty(pAssemblyNameDLL)) { return tMyAssembly; }
			try //try #a
			{
				if (!pAssemblyNameDLL.ToLower().EndsWith(".dll")) { pAssemblyNameDLL += ".dll"; }
				tMyAssembly = System.Reflection.Assembly.LoadFrom(pAssemblyNameDLL);
			}// try #a
			catch (Exception ex)
			{
				string m = ex.Message;
			}// try #a
			return tMyAssembly;
		}//System.Reflection.Assembly GetAssemblyFile(string pAssemblyNameDLL)
        public static string GetVersionStringFromAssembly(string pAssemblyDisplayName)
		{
			string tVersion = "Unknown";
			System.Reflection.Assembly tMyAssembly = null;
			tMyAssembly = GetAssembly(pAssemblyDisplayName);
			if (tMyAssembly == null) { return tVersion; }
			tVersion = GetVersionString(tMyAssembly.GetName().Version.ToString());
			return tVersion;
		}//string GetVersionStringFromAssemblyEmbedded(string pAssemblyDisplayName)
		public static string GetVersionString(Version pVersion)
		{
			string tVersion = "Unknown";
			if (pVersion == null) { return tVersion; }
			tVersion = GetVersionString(pVersion.ToString());
			return tVersion;
		}//string GetVersionString(Version pVersion)
		public static string GetVersionString(string pVersionString)
		{
			string tVersion = "Unknown";
			string[] aVersion;
			if (string.IsNullOrEmpty(pVersionString)) { return tVersion; }
			aVersion = pVersionString.Split('.');
			if (aVersion.Length > 0) { tVersion = aVersion[0]; }
			if (aVersion.Length > 1) { tVersion += "." + aVersion[1]; }
			if (aVersion.Length > 2) { tVersion += "." + aVersion[2].PadLeft(4, '0'); }
			if (aVersion.Length > 3) { tVersion += "." + aVersion[3].PadLeft(4, '0'); }
			return tVersion;
		}//string GetVersionString(Version pVersion)
		public static string GetVersionStringFromAssemblyEmbedded(string pAssemblyDisplayName)
		{
			string tVersion = "Unknown";
			System.Reflection.Assembly tMyAssembly = null;
			tMyAssembly = GetAssemblyEmbedded(pAssemblyDisplayName);
			if (tMyAssembly == null) { return tVersion; }
			tVersion = GetVersionString(tMyAssembly.GetName().Version.ToString());
			return tVersion;
		}//string GetVersionStringFromAssemblyEmbedded(string pAssemblyDisplayName)
		public static string GetVersionStringFromAssemblyDLL(string pAssemblyDisplayName)
		{
			string tVersion = "Unknown";
			System.Reflection.Assembly tMyAssembly = null;
			tMyAssembly = GetAssemblyDLL(pAssemblyDisplayName);
			if (tMyAssembly == null) { return tVersion; }
			tVersion = GetVersionString(tMyAssembly.GetName().Version.ToString());
			return tVersion;
		}//string GetVersionStringFromAssemblyEmbedded(string pAssemblyDisplayName)
