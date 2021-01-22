        using System.Runtime.InteropServices;
        [DllImport (@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(
            System.UInt32 pBC, 
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
            [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
            System.UInt32 cbSize,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
            System.UInt32 dwMimeFlags,
            out System.UInt32 ppwzMimeOut,
            System.UInt32 dwReserverd
        );
        private string GetMimeFromRegistry (string Filename)
        {
            string mime = "application/octetstream";
            string ext = System.IO.Path.GetExtension(Filename).ToLower();
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (rk != null && rk.GetValue("Content Type") != null)
                mime = rk.GetValue("Content Type").ToString();
            return mime;
        }
        public string GetMimeTypeFromFileAndRegistry (string filename)
        {
            if (!File.Exists(filename))
            {
               return GetMimeFromRegistry (filename);
            }
            byte[] buffer = new byte[256];
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                if (fs.Length >= 256)
                    fs.Read(buffer, 0, 256);
                else
                    fs.Read(buffer, 0, (int)fs.Length);
            }
            try
            {            
                System.UInt32 mimetype;
                FindMimeFromData(0, null, buffer, 256, null, 0, out mimetype, 0);
                System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                string mime = Marshal.PtrToStringUni(mimeTypePtr);
                Marshal.FreeCoTaskMem(mimeTypePtr);
                if (string.IsNullOrWhiteSpace (mime) || 
                    mime =="text/plain" || mime == "application/octet-stream")                    
                {
                    return GetMimeFromRegistry (filename);
                }
                return mime;
            }
            catch (Exception e)
            {
                return GetMimeFromRegistry (filename);
            }
        }
