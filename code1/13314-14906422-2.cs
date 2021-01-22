    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    
    // Change the namespace to match your program's normal namespace
    namespace MyProg
    {
    	class IniFile
    	{
    		public string Path;
    		static string EXE = Assembly.GetExecutingAssembly().GetName().Name;
    
    		[DllImport("kernel32")]
    		static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);
    
    		[DllImport("kernel32")]
    		static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
    
    		public IniFile(string IniPath = null)
    		{
    			Path = new FileInfo(IniPath != null ? IniPath : EXE + ".ini").FullName.ToString();
    		}
    
    		public string Read(string Key, string Section = null)
    		{
    			StringBuilder RetVal = new StringBuilder(255);
    			GetPrivateProfileString(Section != null ? Section : EXE, Key, "", RetVal, 255, Path);
    			return RetVal.ToString();
    		}
    
    		public void Write(string Key, string Value, string Section = null)
    		{
    			WritePrivateProfileString(Section != null ? Section : EXE, Key, Value, Path);
    		}
    
    		public void DeleteKey(string Key, string Section = null)
    		{
    			Write(Key, null, Section != null ? Section : EXE);
    		}
    
    		public void DeleteSection(string Section = null)
    		{
    			Write(null, null, Section != null ? Section : EXE);
    		}
    
    		public bool KeyExists(string Key, string Section = null)
    		{
    			return Read(Key, Section).Length > 0 ? true : false;
    		}
    	}
    }
