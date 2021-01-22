    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Diagnostics;
    
    
    namespace WindowsFormsApplication1
    {
    	static class Program
    	{
    		[DllImport("Shlwapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
    		static extern uint AssocQueryString(AssocF flags, AssocStr str, string pszAssoc, string pszExtra, [Out] StringBuilder pszOut, [In][Out] ref uint pcchOut);
    
    		/// <summary>
    		/// The main entry point for the application.
    		/// </summary>
    		[STAThread]
    		static void Main()
    		{
    			Debug.WriteLine(FileExtentionInfo(AssocStr.Command, ".doc"), "Command");
    			Debug.WriteLine(FileExtentionInfo(AssocStr.DDEApplication, ".doc"), "DDEApplication");
    			Debug.WriteLine(FileExtentionInfo(AssocStr.DDEIfExec, ".doc"), "DDEIfExec");
    			Debug.WriteLine(FileExtentionInfo(AssocStr.DDETopic, ".doc"), "DDETopic");
    			Debug.WriteLine(FileExtentionInfo(AssocStr.Executable, ".doc"), "Executable");
    			Debug.WriteLine(FileExtentionInfo(AssocStr.FriendlyAppName, ".doc"), "FriendlyAppName");
    			Debug.WriteLine(FileExtentionInfo(AssocStr.FriendlyDocName, ".doc"), "FriendlyDocName");
    			Debug.WriteLine(FileExtentionInfo(AssocStr.NoOpen, ".doc"), "NoOpen");
    			Debug.WriteLine(FileExtentionInfo(AssocStr.ShellNewValue, ".doc"), "ShellNewValue");
    
    			//	DDEApplication: WinWord
    			//DDEIfExec: Ñﻴ߾
    			//	DDETopic: System
    			//	Executable: C:\Program Files (x86)\Microsoft Office\Office12\WINWORD.EXE
    			//	FriendlyAppName: Microsoft Office Word
    			//	FriendlyDocName: Microsoft Office Word 97 - 2003 Document
    
    
    		}
    
    		public static string FileExtentionInfo(AssocStr assocStr, string doctype)
    		{
    			uint pcchOut = 0;
    			AssocQueryString(AssocF.Verify, assocStr, doctype, null, null, ref pcchOut);
    
    			StringBuilder pszOut = new StringBuilder((int)pcchOut);
    			AssocQueryString(AssocF.Verify, assocStr, doctype, null, pszOut, ref pcchOut);
    			return pszOut.ToString();
    		}
    
    		[Flags]
    		public enum AssocF
    		{
    			Init_NoRemapCLSID = 0x1,
    			Init_ByExeName = 0x2,
    			Open_ByExeName = 0x2,
    			Init_DefaultToStar = 0x4,
    			Init_DefaultToFolder = 0x8,
    			NoUserSettings = 0x10,
    			NoTruncate = 0x20,
    			Verify = 0x40,
    			RemapRunDll = 0x80,
    			NoFixUps = 0x100,
    			IgnoreBaseClass = 0x200
    		}
    
    		public enum AssocStr
    		{
    			Command = 1,
    			Executable,
    			FriendlyDocName,
    			FriendlyAppName,
    			NoOpen,
    			ShellNewValue,
    			DDECommand,
    			DDEIfExec,
    			DDEApplication,
    			DDETopic
    		}
    
    	}
    }
