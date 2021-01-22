    /*
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    */
         public static ImageSource GetIcon(string strPath, bool bSmall)
            {
              Interop.SHFILEINFO info = new Interop.SHFILEINFO(true);
              int cbFileInfo = Marshal.SizeOf(info);
              Interop.SHGFI flags;
              if (bSmall)
                flags = Interop.SHGFI.Icon | Interop.SHGFI.SmallIcon | Interop.SHGFI.UseFileAttributes;
              else
                flags = Interop.SHGFI.Icon | Interop.SHGFI.LargeIcon | Interop.SHGFI.UseFileAttributes;
        
              Interop.SHGetFileInfo(strPath, 256, out info, (uint)cbFileInfo, flags);
        
              IntPtr iconHandle = info.hIcon;
              //if (IntPtr.Zero == iconHandle) // not needed, always return icon (blank)
              //  return DefaultImgSrc;
              ImageSource img = Imaging.CreateBitmapSourceFromHIcon(
                          iconHandle,
                          Int32Rect.Empty,
                          BitmapSizeOptions.FromEmptyOptions());
              Interop.DestroyIcon(iconHandle);
              return img;
            }
    
