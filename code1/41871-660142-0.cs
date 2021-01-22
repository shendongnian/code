    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    
    namespace SomeNamespace
    {
        /// <summary>
        /// This will work only on windows
        /// </summary>
        public class MimeTypeFinder
        {
            [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
            private extern static UInt32 FindMimeFromData(
                UInt32 pBC,
                [MarshalAs(UnmanagedType.LPStr)] String pwzUrl,
                [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
                UInt32 cbSize,
                [MarshalAs(UnmanagedType.LPStr)]String pwzMimeProposed,
                UInt32 dwMimeFlags,
                out UInt32 ppwzMimeOut,
                UInt32 dwReserverd
            );
    
            public string GetMimeFromFile(string filename)
            {
                if (!File.Exists(filename))
                    throw new FileNotFoundException(filename + " not found");
    
                var buffer = new byte[256];
                using (var fs = new FileStream(filename, FileMode.Open))
                {
                    if (fs.Length >= 256)
                        fs.Read(buffer, 0, 256);
                    else
                        fs.Read(buffer, 0, (int)fs.Length);
                }
                try
                {
                    UInt32 mimetype;
                    FindMimeFromData(0, null, buffer, 256, null, 0, out mimetype, 0);
                    var mimeTypePtr = new IntPtr(mimetype);
                    var mime = Marshal.PtrToStringUni(mimeTypePtr);
                    Marshal.FreeCoTaskMem(mimeTypePtr);
                    return mime;
                }
                catch (Exception)
                {
                    return "unknown/unknown";
                }
            }
        }
    }
