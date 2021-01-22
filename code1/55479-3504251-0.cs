    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.Text;
    using System.Threading;
    
    namespace FileLockInfo {
    
    	public class Win32Processes {
    		
    		/// <summary>
    		/// Return a list of processes that hold on the given file.
    		/// </summary>
    		public static List<Process> GetProcessesLockingFile (string filePath) {
    			var procs = new List<Process>();
    
    			foreach (var process in Process.GetProcesses()) {
    				var files = GetFilesLockedBy(process);
    				if (files.Contains(filePath)) procs.Add(process);
    			}
    			return procs;
    		}
    		
    		/// <summary>
    		/// Return a list of file locks held by the process.
    		/// </summary>
    		public static List<string> GetFilesLockedBy (Process process) {
    			var outp = new List<string>();
    
    			ThreadStart ts = delegate {
    				try {
    					outp = UnsafeGetFilesLockedBy(process);
    				} catch {
    				}
    			};
    
    
    			try {
    				var t = new Thread(ts);
    				t.Start();
    				if (!t.Join(250)) {
    					try {
    						t.Abort();
    					} catch { }
    				}
    			} catch {
    			}
    
    			return outp;
    		}
    
    		#region Inner Workings
    		private static List<string> UnsafeGetFilesLockedBy (Process process) {
    			try {
    				var handles = GetHandles(process);
    				var files = new List<string>();
    
    				foreach (var handle in handles) {
    					var file = GetFilePath(handle, process);
    					if (file != null) files.Add(file);
    				}
    
    				return files;
    			} catch {
    				return new List<string>();
    			}
    		}
    
    		const int CNST_SYSTEM_HANDLE_INFORMATION = 16;
    		const uint STATUS_INFO_LENGTH_MISMATCH = 0xc0000004;
    		private static string GetFilePath (Win32API.SYSTEM_HANDLE_INFORMATION sYSTEM_HANDLE_INFORMATION, Process process) {
    			IntPtr m_ipProcessHwnd = Win32API.OpenProcess(Win32API.ProcessAccessFlags.All, false, process.Id);
    			IntPtr ipHandle = IntPtr.Zero;
    			var objBasic = new Win32API.OBJECT_BASIC_INFORMATION();
    			IntPtr ipBasic = IntPtr.Zero;
    			var objObjectType = new Win32API.OBJECT_TYPE_INFORMATION();
    			IntPtr ipObjectType = IntPtr.Zero;
    			var objObjectName = new Win32API.OBJECT_NAME_INFORMATION();
    			IntPtr ipObjectName = IntPtr.Zero;
    			string strObjectTypeName = "";
    			string strObjectName = "";
    			int nLength = 0;
    			int nReturn = 0;
    			IntPtr ipTemp = IntPtr.Zero;
    
    			if (!Win32API.DuplicateHandle(m_ipProcessHwnd, sYSTEM_HANDLE_INFORMATION.Handle, Win32API.GetCurrentProcess(), out ipHandle, 0, false, Win32API.DUPLICATE_SAME_ACCESS))
    				return null;
    
    			ipBasic = Marshal.AllocHGlobal(Marshal.SizeOf(objBasic));
    			Win32API.NtQueryObject(ipHandle, (int)Win32API.ObjectInformationClass.ObjectBasicInformation, ipBasic, Marshal.SizeOf(objBasic), ref nLength);
    			objBasic = (Win32API.OBJECT_BASIC_INFORMATION)Marshal.PtrToStructure(ipBasic, objBasic.GetType());
    			Marshal.FreeHGlobal(ipBasic);
    
    
    			ipObjectType = Marshal.AllocHGlobal(objBasic.TypeInformationLength);
    			nLength = objBasic.TypeInformationLength;
    			while ((uint)(nReturn = Win32API.NtQueryObject(ipHandle, (int)Win32API.ObjectInformationClass.ObjectTypeInformation, ipObjectType, nLength, ref nLength)) == Win32API.STATUS_INFO_LENGTH_MISMATCH) {
    				Marshal.FreeHGlobal(ipObjectType);
    				ipObjectType = Marshal.AllocHGlobal(nLength);
    			}
    
    			objObjectType = (Win32API.OBJECT_TYPE_INFORMATION)Marshal.PtrToStructure(ipObjectType, objObjectType.GetType());
    			if (Is64Bits()) {
    				ipTemp = new IntPtr(Convert.ToInt64(objObjectType.Name.Buffer.ToString(), 10) >> 32);
    			} else {
    				ipTemp = objObjectType.Name.Buffer;
    			}
    
    			strObjectTypeName = Marshal.PtrToStringUni(ipTemp, objObjectType.Name.Length >> 1);
    			Marshal.FreeHGlobal(ipObjectType);
    			if (strObjectTypeName != "File")
    				return null;
    
    			nLength = objBasic.NameInformationLength;
    
    			ipObjectName = Marshal.AllocHGlobal(nLength);
    			while ((uint)(nReturn = Win32API.NtQueryObject(ipHandle, (int)Win32API.ObjectInformationClass.ObjectNameInformation, ipObjectName, nLength, ref nLength)) == Win32API.STATUS_INFO_LENGTH_MISMATCH) {
    				Marshal.FreeHGlobal(ipObjectName);
    				ipObjectName = Marshal.AllocHGlobal(nLength);
    			}
    			objObjectName = (Win32API.OBJECT_NAME_INFORMATION)Marshal.PtrToStructure(ipObjectName, objObjectName.GetType());
    
    			if (Is64Bits()) {
    				ipTemp = new IntPtr(Convert.ToInt64(objObjectName.Name.Buffer.ToString(), 10) >> 32);
    			} else {
    				ipTemp = objObjectName.Name.Buffer;
    			}
    
    			if (ipTemp != IntPtr.Zero) {
    
    				byte[] baTemp = new byte[nLength];
    				try {
    					Marshal.Copy(ipTemp, baTemp, 0, nLength);
    
    					strObjectName = Marshal.PtrToStringUni(Is64Bits() ? new IntPtr(ipTemp.ToInt64()) : new IntPtr(ipTemp.ToInt32()));
    				} catch (AccessViolationException) {
    					return null;
    				} finally {
    					Marshal.FreeHGlobal(ipObjectName);
    					Win32API.CloseHandle(ipHandle);
    				}
    			}
    
    			string path = GetRegularFileNameFromDevice(strObjectName);
    			try {
    				return path;
    			} catch {
    				return null;
    			}
    		}
    
    		private static string GetRegularFileNameFromDevice (string strRawName) {
    			string strFileName = strRawName;
    			foreach (string strDrivePath in Environment.GetLogicalDrives()) {
    				StringBuilder sbTargetPath = new StringBuilder(Win32API.MAX_PATH);
    				if (Win32API.QueryDosDevice(strDrivePath.Substring(0, 2), sbTargetPath, Win32API.MAX_PATH) == 0) {
    					return strRawName;
    				}
    				string strTargetPath = sbTargetPath.ToString();
    				if (strFileName.StartsWith(strTargetPath)) {
    					strFileName = strFileName.Replace(strTargetPath, strDrivePath.Substring(0, 2));
    					break;
    				}
    			}
    			return strFileName;
    		}
    
    		private static List<Win32API.SYSTEM_HANDLE_INFORMATION> GetHandles (Process process) {
    			uint nStatus;
    			int nHandleInfoSize = 0x10000;
    			IntPtr ipHandlePointer = Marshal.AllocHGlobal(nHandleInfoSize);
    			int nLength = 0;
    			IntPtr ipHandle = IntPtr.Zero;
    
    			while ((nStatus = Win32API.NtQuerySystemInformation(CNST_SYSTEM_HANDLE_INFORMATION, ipHandlePointer, nHandleInfoSize, ref nLength)) == STATUS_INFO_LENGTH_MISMATCH) {
    				nHandleInfoSize = nLength;
    				Marshal.FreeHGlobal(ipHandlePointer);
    				ipHandlePointer = Marshal.AllocHGlobal(nLength);
    			}
    
    			byte[] baTemp = new byte[nLength];
    			Marshal.Copy(ipHandlePointer, baTemp, 0, nLength);
    
    			long lHandleCount = 0;
    			if (Is64Bits()) {
    				lHandleCount = Marshal.ReadInt64(ipHandlePointer);
    				ipHandle = new IntPtr(ipHandlePointer.ToInt64() + 8);
    			} else {
    				lHandleCount = Marshal.ReadInt32(ipHandlePointer);
    				ipHandle = new IntPtr(ipHandlePointer.ToInt32() + 4);
    			}
    
    			Win32API.SYSTEM_HANDLE_INFORMATION shHandle;
    			List<Win32API.SYSTEM_HANDLE_INFORMATION> lstHandles = new List<Win32API.SYSTEM_HANDLE_INFORMATION>();
    
    			for (long lIndex = 0; lIndex < lHandleCount; lIndex++) {
    				shHandle = new Win32API.SYSTEM_HANDLE_INFORMATION();
    				if (Is64Bits()) {
    					shHandle = (Win32API.SYSTEM_HANDLE_INFORMATION)Marshal.PtrToStructure(ipHandle, shHandle.GetType());
    					ipHandle = new IntPtr(ipHandle.ToInt64() + Marshal.SizeOf(shHandle) + 8);
    				} else {
    					ipHandle = new IntPtr(ipHandle.ToInt64() + Marshal.SizeOf(shHandle));
    					shHandle = (Win32API.SYSTEM_HANDLE_INFORMATION)Marshal.PtrToStructure(ipHandle, shHandle.GetType());
    				}
    				if (shHandle.ProcessID != process.Id) continue;
    				lstHandles.Add(shHandle);
    			}
    			return lstHandles;
    
    		}
    
    		private static bool Is64Bits () {
    			return Marshal.SizeOf(typeof(IntPtr)) == 8 ? true : false;
    		}
    
    		internal class Win32API {
    			[DllImport("ntdll.dll")]
    			public static extern int NtQueryObject (IntPtr ObjectHandle, int
    				ObjectInformationClass, IntPtr ObjectInformation, int ObjectInformationLength,
    				ref int returnLength);
    
    			[DllImport("kernel32.dll", SetLastError = true)]
    			public static extern uint QueryDosDevice (string lpDeviceName, StringBuilder lpTargetPath, int ucchMax);
    
    			[DllImport("ntdll.dll")]
    			public static extern uint NtQuerySystemInformation (int
    				SystemInformationClass, IntPtr SystemInformation, int SystemInformationLength,
    				ref int returnLength);
    
    			[DllImport("kernel32.dll")]
    			public static extern IntPtr OpenProcess (ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);
    			[DllImport("kernel32.dll")]
    			public static extern int CloseHandle (IntPtr hObject);
    			[DllImport("kernel32.dll", SetLastError = true)]
    			[return: MarshalAs(UnmanagedType.Bool)]
    			public static extern bool DuplicateHandle (IntPtr hSourceProcessHandle,
    			   ushort hSourceHandle, IntPtr hTargetProcessHandle, out IntPtr lpTargetHandle,
    			   uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwOptions);
    			[DllImport("kernel32.dll")]
    			public static extern IntPtr GetCurrentProcess ();
    
    			public enum ObjectInformationClass : int {
    				ObjectBasicInformation = 0,
    				ObjectNameInformation = 1,
    				ObjectTypeInformation = 2,
    				ObjectAllTypesInformation = 3,
    				ObjectHandleInformation = 4
    			}
    
    			[Flags]
    			public enum ProcessAccessFlags : uint {
    				All = 0x001F0FFF,
    				Terminate = 0x00000001,
    				CreateThread = 0x00000002,
    				VMOperation = 0x00000008,
    				VMRead = 0x00000010,
    				VMWrite = 0x00000020,
    				DupHandle = 0x00000040,
    				SetInformation = 0x00000200,
    				QueryInformation = 0x00000400,
    				Synchronize = 0x00100000
    			}
    
    			[StructLayout(LayoutKind.Sequential)]
    			public struct OBJECT_BASIC_INFORMATION { // Information Class 0
    				public int Attributes;
    				public int GrantedAccess;
    				public int HandleCount;
    				public int PointerCount;
    				public int PagedPoolUsage;
    				public int NonPagedPoolUsage;
    				public int Reserved1;
    				public int Reserved2;
    				public int Reserved3;
    				public int NameInformationLength;
    				public int TypeInformationLength;
    				public int SecurityDescriptorLength;
    				public System.Runtime.InteropServices.ComTypes.FILETIME CreateTime;
    			}
    
    			[StructLayout(LayoutKind.Sequential)]
    			public struct OBJECT_TYPE_INFORMATION { // Information Class 2
    				public UNICODE_STRING Name;
    				public int ObjectCount;
    				public int HandleCount;
    				public int Reserved1;
    				public int Reserved2;
    				public int Reserved3;
    				public int Reserved4;
    				public int PeakObjectCount;
    				public int PeakHandleCount;
    				public int Reserved5;
    				public int Reserved6;
    				public int Reserved7;
    				public int Reserved8;
    				public int InvalidAttributes;
    				public GENERIC_MAPPING GenericMapping;
    				public int ValidAccess;
    				public byte Unknown;
    				public byte MaintainHandleDatabase;
    				public int PoolType;
    				public int PagedPoolUsage;
    				public int NonPagedPoolUsage;
    			}
    
    			[StructLayout(LayoutKind.Sequential)]
    			public struct OBJECT_NAME_INFORMATION { // Information Class 1
    				public UNICODE_STRING Name;
    			}
    
    			[StructLayout(LayoutKind.Sequential, Pack = 1)]
    			public struct UNICODE_STRING {
    				public ushort Length;
    				public ushort MaximumLength;
    				public IntPtr Buffer;
    			}
    
    			[StructLayout(LayoutKind.Sequential)]
    			public struct GENERIC_MAPPING {
    				public int GenericRead;
    				public int GenericWrite;
    				public int GenericExecute;
    				public int GenericAll;
    			}
    
    			[StructLayout(LayoutKind.Sequential, Pack = 1)]
    			public struct SYSTEM_HANDLE_INFORMATION { // Information Class 16
    				public int ProcessID;
    				public byte ObjectTypeNumber;
    				public byte Flags; // 0x01 = PROTECT_FROM_CLOSE, 0x02 = INHERIT
    				public ushort Handle;
    				public int Object_Pointer;
    				public UInt32 GrantedAccess;
    			}
    
    			public const int MAX_PATH = 260;
    			public const uint STATUS_INFO_LENGTH_MISMATCH = 0xC0000004;
    			public const int DUPLICATE_SAME_ACCESS = 0x2;
    		}
    		#endregion
    	}
    }
