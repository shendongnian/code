    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    namespace ConsoleApplication1
    {
        internal class WeirdFilename
        {
            public static void Test()
            {
                //string formattedName = @"\\?\c:\temp\dot.";
                string formattedName = @"\\?\UNC\m1330\c$\temp\dot.";
                SafeFileHandle fileHandle = CreateFile(formattedName,
                                                        EFileAccess.GenericRead, EFileShare.None, IntPtr.Zero,
                                                        ECreationDisposition.OpenExisting, 0, IntPtr.Zero);
                // Check for errors
                int lastWin32Error = Marshal.GetLastWin32Error();
                if (fileHandle.IsInvalid)
                {
                    throw new Win32Exception(lastWin32Error);
                }
                // Pass the file handle to FileStream. FileStream will close the handle
                using (FileStream fs = new FileStream(fileHandle, FileAccess.Read))
                {
                    StreamReader reader = new StreamReader(fs);
                }
            }
            #region ECreationDisposition enum
            public enum ECreationDisposition : uint
            {
                New = 1,
                CreateAlways = 2,
                OpenExisting = 3,
                OpenAlways = 4,
                TruncateExisting = 5,
            }
            #endregion
            #region EFileAccess enum
            [Flags]
            public enum EFileAccess : uint
            {
                GenericRead = 0x80000000,
                GenericWrite = 0x40000000,
                GenericExecute = 0x20000000,
                GenericAll = 0x10000000,
            }
            #endregion
            #region EFileAttributes enum
            [Flags]
            public enum EFileAttributes : uint
            {
                Readonly = 0x00000001,
                Hidden = 0x00000002,
                System = 0x00000004,
                Directory = 0x00000010,
                Archive = 0x00000020,
                Device = 0x00000040,
                Normal = 0x00000080,
                Temporary = 0x00000100,
                SparseFile = 0x00000200,
                ReparsePoint = 0x00000400,
                Compressed = 0x00000800,
                Offline = 0x00001000,
                NotContentIndexed = 0x00002000,
                Encrypted = 0x00004000,
                Write_Through = 0x80000000,
                Overlapped = 0x40000000,
                NoBuffering = 0x20000000,
                RandomAccess = 0x10000000,
                SequentialScan = 0x08000000,
                DeleteOnClose = 0x04000000,
                BackupSemantics = 0x02000000,
                PosixSemantics = 0x01000000,
                OpenReparsePoint = 0x00200000,
                OpenNoRecall = 0x00100000,
                FirstPipeInstance = 0x00080000
            }
            #endregion
            #region EFileShare enum
            [Flags]
            public enum EFileShare : uint
            {
                None = 0x00000000,
                Read = 0x00000001,
                Write = 0x00000002,
                Delete = 0x00000004,
            }
            #endregion
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern SafeFileHandle CreateFile(
                string lpFileName,
                EFileAccess dwDesiredAccess,
                EFileShare dwShareMode,
                IntPtr lpSecurityAttributes,
                ECreationDisposition dwCreationDisposition,
                EFileAttributes dwFlagsAndAttributes,
                IntPtr hTemplateFile);
        }
    }
