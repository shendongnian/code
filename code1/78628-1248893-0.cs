    /* 
    All sample code is provided by the Inge Henriksen for illustrative purposes only. These examples have not been thoroughly tested under all conditions. Inge Henriksen, therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
     */
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Win32.SafeHandles;
    using System.Runtime.InteropServices;
    using System.IO;
    using log4net;
    
    namespace MyStuff.DAL.Services.IO.File
    {
        /// <summary>
        /// Class for communicating with the Windows kernel library for low-level disk access.
        /// The main purpose of this class is to allow for longer file paths than System.IO.File,
        /// this class handles file paths up to 32,767 characters. 
        /// Note: Always be careful when accessing this class from a managed multi-threaded application
        /// as the unmanaged Windows kernel is different, this "crash" causes application unstability 
        /// if not handled properly.
        /// TODO: Look into if there are any significant gains on 64-bit systems using another kind of 
        /// core component than kernel32.dll.
        /// </summary>
        public class Win32File
        {
            ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    
            #region DLLImport's
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            static extern bool MoveFile(string lpExistingFileName, string lpNewFileName);
    
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            static extern bool DeleteFile(string lpFileName);
    
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            static extern bool CreateDirectoryW(string lpPathName, IntPtr lpSecurityAttributes);
    
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            static extern SafeFileHandle CreateFileW(string lpFileName, uint dwDesiredAccess,
                                                  uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition,
                                                  uint dwFlagsAndAttributes, IntPtr hTemplateFile);
    
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            static extern uint SetFilePointer(SafeFileHandle hFile, long lDistanceToMove, IntPtr lpDistanceToMoveHigh, uint dwMoveMethod);
    
            #endregion
            
            // uint GetMode( FileMode mode )
            // Converts the filemode constant to win32 constant
            #region GetMode
            private uint GetMode(FileMode mode)
            {
                Log.Debug("Get Win32 file mode");
                uint umode = 0;
                switch (mode)
                {
                    case FileMode.CreateNew:
                        umode = Win32FileAttributes.CREATE_NEW;
                        break;
                    case FileMode.Create:
                        umode = Win32FileAttributes.CREATE_ALWAYS;
                        break;
                    case FileMode.Append:
                        umode = Win32FileAttributes.OPEN_ALWAYS;
                        break;
                    case FileMode.Open:
                        umode = Win32FileAttributes.OPEN_EXISTING;
                        break;
                    case FileMode.OpenOrCreate:
                        umode = Win32FileAttributes.OPEN_ALWAYS;
                        break;
                    case FileMode.Truncate:
                        umode = Win32FileAttributes.TRUNCATE_EXISTING;
                        break;
                }
                return umode;
            }
            #endregion
    
            // uint GetAccess(FileAccess access)
            // Converts the FileAccess constant to win32 constant
            #region GetAccess
            private uint GetAccess(FileAccess access)
            {
                Log.Debug("Get Win32 file access");
                uint uaccess = 0;
                switch (access)
                {
                    case FileAccess.Read:
                        uaccess = Win32FileAttributes.GENERIC_READ;
                        break;
                    case FileAccess.ReadWrite:
                        uaccess = Win32FileAttributes.GENERIC_READ | Win32FileAttributes.GENERIC_WRITE;
                        break;
                    case FileAccess.Write:
                        uaccess = Win32FileAttributes.GENERIC_WRITE;
                        break;
                }
                return uaccess;
            }
            #endregion
    
            // uint GetShare(FileShare share)
            // Converts the FileShare constant to win32 constant
            #region GetShare
            private uint GetShare(FileShare share)
            {
                Log.Debug("Get Win32 file share");
                uint ushare = 0;
                switch (share)
                {
                    case FileShare.Read:
                        ushare = Win32FileAttributes.FILE_SHARE_READ;
                        break;
                    case FileShare.ReadWrite:
                        ushare = Win32FileAttributes.FILE_SHARE_READ | Win32FileAttributes.FILE_SHARE_WRITE;
                        break;
                    case FileShare.Write:
                        ushare = Win32FileAttributes.FILE_SHARE_WRITE;
                        break;
                    case FileShare.Delete:
                        ushare = Win32FileAttributes.FILE_SHARE_DELETE;
                        break;
                    case FileShare.None:
                        ushare = 0;
                        break;
    
                }
                return ushare;
            }
            #endregion
    
            public bool Move(string existingFile, string newFile)
            {
                Log.Debug(String.Format("Rename the file \"{0}\" to \"{1}\"", existingFile, newFile) );
                return Win32File.MoveFile(existingFile, newFile);
            }
    
            public bool CreateDirectory(string filepath)
            {
                Log.Debug(String.Format("Create the directory \"{0}\"", filepath));
                // If file path is disk file path then prepend it with \\?\
                // if file path is UNC prepend it with \\?\UNC\ and remove \\ prefix in unc path.
                if (filepath.StartsWith(@"\\"))
                    filepath = @"\\?\UNC\" + filepath.Substring(2, filepath.Length - 2);
                else
                    filepath = @"\\?\" + filepath;
                return CreateDirectoryW(filepath, IntPtr.Zero);
            }
    
            public FileStream Open(string filepath, FileMode mode, uint uaccess)
            {
                Log.Debug(String.Format("Open the file \"{0}\"", filepath));
    
                //opened in the specified mode and path, with read/write access and not shared
                FileStream fs = null;
                uint umode = GetMode(mode);
                uint ushare = 0;    // Not shared
                if (mode == FileMode.Append) uaccess = Win32FileAttributes.FILE_APPEND_DATA;
    
                // If file path is disk file path then prepend it with \\?\
                // if file path is UNC prepend it with \\?\UNC\ and remove \\ prefix in unc path.
                if (filepath.StartsWith(@"\\"))
                    filepath = @"\\?\UNC\" + filepath.Substring(2, filepath.Length - 2);
                else filepath = @"\\?\" + filepath;
    
                SafeFileHandle sh = CreateFileW(filepath, uaccess, ushare, IntPtr.Zero, umode, Win32FileAttributes.FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
                int iError = Marshal.GetLastWin32Error();
                if ((iError > 0 && !(mode == FileMode.Append && iError == Win32FileAttributes.ERROR_ALREADY_EXISTS)) || sh.IsInvalid)
                {
                    Log.Error(String.Format("Error opening file; Win32 Error: {0}", iError));
                    throw new Exception("Error opening file; Win32 Error:" + iError);
                }
                else
                {
                    fs = new FileStream(sh, FileAccess.ReadWrite);
                }
    
                // if opened in append mode
                if (mode == FileMode.Append)
                {
                    if (!sh.IsInvalid)
                    {
                        SetFilePointer(sh, 0, IntPtr.Zero, Win32FileAttributes.FILE_END);
                    }
                }
    
                Log.Debug(String.Format("The file \"{0}\" is now open", filepath));
                return fs;
            }
    
            public FileStream Open(string filepath, FileMode mode, FileAccess access)
            {
                Log.Debug(String.Format("Open the file \"{0}\"", filepath));
    
                //opened in the specified mode and access and not shared
                FileStream fs = null;
                uint umode = GetMode(mode);
                uint uaccess = GetAccess(access);
                uint ushare = 0;    // Exclusive lock of the file
    
                if (mode == FileMode.Append) uaccess = Win32FileAttributes.FILE_APPEND_DATA;
    
                // If file path is disk file path then prepend it with \\?\
                // if file path is UNC prepend it with \\?\UNC\ and remove \\ prefix in unc path.
                if (filepath.StartsWith(@"\\"))
                    filepath = @"\\?\UNC\" + filepath.Substring(2, filepath.Length - 2);
                else
                    filepath = @"\\?\" + filepath;
    
                SafeFileHandle sh = CreateFileW(filepath, uaccess, ushare, IntPtr.Zero, umode, Win32FileAttributes.FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
                int iError = Marshal.GetLastWin32Error();
                if ((iError > 0 && !(mode == FileMode.Append && iError != Win32FileAttributes.ERROR_ALREADY_EXISTS)) || sh.IsInvalid)
                {
                    Log.Error(String.Format("Error opening file; Win32 Error: {0}", iError));
                    throw new Exception("Error opening file; Win32 Error:" + iError);
                }
                else
                {
                    fs = new FileStream(sh, access);
                }
    
                // if opened in append mode
                if (mode == FileMode.Append)
                {
                    if (!sh.IsInvalid)
                    {
                        SetFilePointer(sh, 0, IntPtr.Zero, Win32FileAttributes.FILE_END);
                    }
                }
    
                Log.Debug(String.Format("The file \"{0}\" is now open", filepath));
                return fs;
            }
    
            public FileStream Open(string filepath, FileMode mode, FileAccess access, FileShare share)
            {
                //opened in the specified mode , access and  share
                FileStream fs = null;
                uint umode = GetMode(mode);
                uint uaccess = GetAccess(access);
                uint ushare = GetShare(share);
                if (mode == FileMode.Append) uaccess = Win32FileAttributes.FILE_APPEND_DATA;
    
                // If file path is disk file path then prepend it with \\?\
                // if file path is UNC prepend it with \\?\UNC\ and remove \\ prefix in unc path.
                if (filepath.StartsWith(@"\\"))
                    filepath = @"\\?\UNC\" + filepath.Substring(2, filepath.Length - 2);
                else
                    filepath = @"\\?\" + filepath;
                SafeFileHandle sh = CreateFileW(filepath, uaccess, ushare, IntPtr.Zero, umode, Win32FileAttributes.FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
                int iError = Marshal.GetLastWin32Error();
                if ((iError > 0 && !(mode == FileMode.Append && iError != Win32FileAttributes.ERROR_ALREADY_EXISTS)) || sh.IsInvalid)
                {
                    throw new Exception("Error opening file Win32 Error:" + iError);
                }
                else
                {
                    fs = new FileStream(sh, access);
                }
                // if opened in append mode
                if (mode == FileMode.Append)
                {
                    if (!sh.IsInvalid)
                    {
                        SetFilePointer(sh, 0, IntPtr.Zero, Win32FileAttributes.FILE_END);
                    }
                }
                return fs;
            }
    
            public FileStream OpenRead(string filepath)
            {
                Log.Debug(String.Format("Open the file \"{0}\"", filepath));
                // Open readonly file mode open(String, FileMode.Open, FileAccess.Read, FileShare.Read)
                return Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
    
            public FileStream OpenWrite(string filepath)
            {
                Log.Debug(String.Format("Open the file \"{0}\" for writing", filepath));
                //open writable open(String, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None).
                return Open(filepath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            }
    
            public bool Delete(string filepath)
            {
                Log.Debug(String.Format("Delete the file \"{0}\"", filepath));
                // If file path is disk file path then prepend it with \\?\
                // if file path is UNC prepend it with \\?\UNC\ and remove \\ prefix in unc path.
                if (filepath.StartsWith(@"\\"))
                    filepath = @"\\?\UNC\" + filepath.Substring(2, filepath.Length - 2);
                else
                    filepath = @"\\?\" + filepath;
                Log.Debug(String.Format("The file \"{0}\" has been deleted", filepath));
                return DeleteFile(filepath);
            }
        }
    }
