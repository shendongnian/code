        public class WinAPI
        {
            [DllImport("ntdll.dll", SetLastError = true)]
            public static extern IntPtr NtQueryInformationFile(IntPtr fileHandle, ref IO_STATUS_BLOCK IoStatusBlock, IntPtr pInfoBlock, uint length, FILE_INFORMATION_CLASS fileInformation);
    
            public struct IO_STATUS_BLOCK
            {
                uint status;
                ulong information;
            }
            public struct _FILE_INTERNAL_INFORMATION {
              public ulong  IndexNumber;
            } 
    
            // Abbreviated, there are more values than shown
            public enum FILE_INFORMATION_CLASS
            {
                FileDirectoryInformation = 1,     // 1
                FileFullDirectoryInformation,     // 2
                FileBothDirectoryInformation,     // 3
                FileBasicInformation,         // 4
                FileStandardInformation,      // 5
                FileInternalInformation      // 6
            }
            
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool GetFileInformationByHandle(IntPtr hFile,out BY_HANDLE_FILE_INFORMATION lpFileInformation);
            public struct BY_HANDLE_FILE_INFORMATION
            {
                public uint FileAttributes;
                public FILETIME CreationTime;
                public FILETIME LastAccessTime;
                public FILETIME LastWriteTime;
                public uint VolumeSerialNumber;
                public uint FileSizeHigh;
                public uint FileSizeLow;
                public uint NumberOfLinks;
                public uint FileIndexHigh;
                public uint FileIndexLow;
            }
      }
      public class Test
      {
           public ulong ApproachA()
           {
                    WinAPI.IO_STATUS_BLOCK iostatus=new WinAPI.IO_STATUS_BLOCK();
                    WinAPI._FILE_INTERNAL_INFORMATION objectIDInfo = new WinAPI._FILE_INTERNAL_INFORMATION();
                    int structSize = Marshal.SizeOf(objectIDInfo);
   
                    FileInfo fi=new FileInfo(@"C:\Temp\testfile.txt");
                    FileStream fs=fi.Open(FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
                    
                    IntPtr res=WinAPI.NtQueryInformationFile(fs.Handle, ref iostatus, memPtr, (uint)structSize, WinAPI.FILE_INFORMATION_CLASS.FileInternalInformation);
                    objectIDInfo = (WinAPI._FILE_INTERNAL_INFORMATION)Marshal.PtrToStructure(memPtr, typeof(WinAPI._FILE_INTERNAL_INFORMATION));
                    fs.Close();
                    Marshal.FreeHGlobal(memPtr);   
                    return objectIDInfo.IndexNumber;
           }
           public ulong ApproachB()
           {
                   WinAPI.BY_HANDLE_FILE_INFORMATION objectFileInfo=new WinAPI.BY_HANDLE_FILE_INFORMATION();
  
                    FileInfo fi=new FileInfo(@"C:\Temp\testfile.txt");
                    FileStream fs=fi.Open(FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
                    WinAPI.GetFileInformationByHandle(fs.Handle, out objectFileInfo);
                    fs.Close();
                    ulong fileIndex = ((ulong)objectFileInfo.FileIndexHigh << 32) + (ulong)objectFileInfo.FileIndexLow;
                    return fileIndex;   
           }
      }
