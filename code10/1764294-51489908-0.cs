    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace Pillage
    {
        public static class IconManager
        {
            private static readonly Dictionary<string, ImageSource> smallIconCache = new Dictionary<string, ImageSource>();
            private static readonly Dictionary<string, ImageSource> largeIconCache = new Dictionary<string, ImageSource>();
    
            public static ImageSource FindIconForFilename(string fileName, bool isLarge)
            {
                var extension = Path.GetExtension(fileName);
    
                if (extension == null) return null;
    
                var cache = isLarge ? largeIconCache : smallIconCache;
    
                if (cache.TryGetValue(extension, out var icon)) return icon;
    
                icon = IconReader
                    .GetFileIcon(fileName, isLarge ? IconReader.IconSize.Large : IconReader.IconSize.Small, false)
                    .ToImageSource();
                cache.Add(extension, icon);
                return icon;
            }
    
            private static ImageSource ToImageSource(this Icon icon)
            {
                var imageSource =
                    Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                return imageSource;
            }
    
            private static class IconReader
            {
                public enum IconSize
                {
                    Large = 0,
                    Small = 1
                }
    
                public static Icon GetFileIcon(string name, IconSize size, bool linkOverlay)
                {
                    var shfi = new Shell32.Shfileinfo();
                    var flags = Shell32.ShgfiIcon | Shell32.ShgfiUsefileattributes;
                    if (linkOverlay) flags += Shell32.ShgfiLinkoverlay;
    
                    if (IconSize.Small == size)
                        flags += Shell32.ShgfiSmallicon;
                    else
                        flags += Shell32.ShgfiLargeicon;
    
                    Shell32.SHGetFileInfo(name,
                        Shell32.FileAttributeNormal,
                        ref shfi,
                        (uint) Marshal.SizeOf(shfi),
                        flags);
    
                    var icon = (Icon) Icon.FromHandle(shfi.hIcon).Clone();
                    User32.DestroyIcon(shfi.hIcon);
    
                    return icon;
                }
            }
    
            private static class Shell32
            {
                private const int MaxPath = 256;
    
                [StructLayout(LayoutKind.Sequential)]
                public struct Shfileinfo
                {
                    private const int Namesize = 80;
                    public readonly IntPtr hIcon;
                    private readonly int iIcon;
                    private readonly uint dwAttributes;
    
                    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxPath)] private readonly string szDisplayName;
                    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Namesize)] private readonly string szTypeName;
                }
    
                public const uint ShgfiIcon = 0x000000100;
                public const uint ShgfiLinkoverlay = 0x000008000;
                public const uint ShgfiLargeicon = 0x000000000;
                public const uint ShgfiSmallicon = 0x000000001;
                public const uint ShgfiUsefileattributes = 0x000000010;
                public const uint FileAttributeNormal = 0x00000080;
    
                [DllImport("Shell32.dll")]
                public static extern IntPtr SHGetFileInfo(
                    string pszPath,
                    uint dwFileAttributes,
                    ref Shfileinfo psfi,
                    uint cbFileInfo,
                    uint uFlags
                );
            }
    
            private static class User32
            {
                [DllImport("User32.dll")]
                public static extern int DestroyIcon(IntPtr hIcon);
            }
        }
    }
