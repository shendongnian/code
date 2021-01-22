    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Drawing;
        
    namespace ExtendedCF {
        public static class WinApi
        {
            #region Icons
            [DllImport("coredll.dll")]
            public static extern bool DestroyIcon(IntPtr hIcon);
            #endregion
        
            #region SHGetFileInfo
            [DllImport("coredll.dll", CharSet = CharSet.Auto)]
            public static extern int SHGetFileInfo(
              string pszPath,
              int dwFileAttributes,
              out SHFILEINFO psfi,
              uint cbfileInfo,
              SHGFI uFlags);
        
            [Flags]
            public enum SHGFI : int
            {
                /// <summary>get icon</summary>
                Icon = 0x000000100,
                /// <summary>get display name</summary>
                DisplayName = 0x000000200,
                /// <summary>get type name</summary>
                TypeName = 0x000000400,
                /// <summary>get attributes</summary>
                Attributes = 0x000000800,
                /// <summary>get icon location</summary>
                IconLocation = 0x000001000,
                /// <summary>return exe type</summary>
                ExeType = 0x000002000,
                /// <summary>get system icon index</summary>
                SysIconIndex = 0x000004000,
                /// <summary>put a link overlay on icon</summary>
                LinkOverlay = 0x000008000,
                /// <summary>show icon in selected state</summary>
                Selected = 0x000010000,
                /// <summary>get only specified attributes</summary>
                Attr_Specified = 0x000020000,
                /// <summary>get large icon</summary>
                LargeIcon = 0x000000000,
                /// <summary>get small icon</summary>
                SmallIcon = 0x000000001,
                /// <summary>get open icon</summary>
                OpenIcon = 0x000000002,
                /// <summary>get shell size icon</summary>
                ShellIconSize = 0x000000004,
                /// <summary>pszPath is a pidl</summary>
                PIDL = 0x000000008,
                /// <summary>use passed dwFileAttribute</summary>
                UseFileAttributes = 0x000000010,
                /// <summary>apply the appropriate overlays</summary>
                AddOverlays = 0x000000020,
                /// <summary>Get the index of the overlay in the upper 8 bits of the iIcon</summary>
                OverlayIndex = 0x000000040,
            }
        
            /// <summary>Maximal Length of unmanaged Windows-Path-strings</summary>
            private const int MAX_PATH = 260;
            /// <summary>Maximal Length of unmanaged Typename</summary>
            private const int MAX_TYPE = 80;
        
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            public struct SHFILEINFO
            {
                public SHFILEINFO(bool dummy)
                {
                    hIcon = IntPtr.Zero;
                    iIcon = 0;
                    dwAttributes = 0;
                    szDisplayName = "";
                    szTypeName = "";
                }
                public IntPtr hIcon;
                public int iIcon;
                public uint dwAttributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
                public string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_TYPE)]
                public string szTypeName;
            };
        
            #endregion
        }
        public static class Utils
        {
            #region GetFileIcon and GetFolderIcon
            /// <summary>
            /// Get the associated Icon for a file or application.  Always returns
            /// an icon.  If the filePath is invalid, the default icon for files of such type is returned.
            /// </summary>
            /// <param name="filePath">full path to the file</param>
            /// <param name="bSmall">if true, return the 16x16 icon; otherwise, the 32x32 icon</param>
            /// <returns></returns>
            private static Icon GetIcon(string filePath, bool bFolder, bool bSmall)
            {
                WinApi.SHFILEINFO info = new WinApi.SHFILEINFO(true);
                int cbFileInfo = Marshal.SizeOf(info);
                WinApi.SHGFI flags = WinApi.SHGFI.Icon | WinApi.SHGFI.UseFileAttributes;
                if (bSmall)
                    flags |= WinApi.SHGFI.SmallIcon;
                else
                    flags |= WinApi.SHGFI.LargeIcon;
        
                int fileAttributes = 0;
                if (bFolder)
                {
                    fileAttributes = (int)FileAttributes.Directory;
                }
        
                WinApi.SHGetFileInfo(filePath, fileAttributes, out info, (uint)cbFileInfo, flags);
                Icon rv = (Icon)Icon.FromHandle(info.hIcon).Clone();
                WinApi.DestroyIcon(info.hIcon);
                return rv;
            }
            private static Icon GetIcon(string filePath, bool bFolder)
            {
                return GetIcon(filePath, bFolder, false);
            }
            public static Icon GetFileIcon(string filePath)
            {
                return GetIcon(filePath, false);
            }
            public static Icon GetFolderIcon(string folderPath)
            {
                return GetIcon(folderPath, true);
            }
            public static Icon GetFileIcon(string filePath, bool bSmall)
            {
                return GetIcon(filePath, false, bSmall);
            }
            public static Icon GetFolderIcon(string folderPath, bool bSmall)
            {
                return GetIcon(folderPath, true, bSmall);
            }
            #endregion
        }
    }
