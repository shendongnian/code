        using System.IO;
        using Microsoft.Win32;
        string GetMimeType(FileInfo fileInfo)
        {
            string mimeType = "application/unknown";
            RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(
                fileInfo.Extension.ToLower()
                );
            if(regKey != null)
            {
                object contentType = regKey.GetValue("Content Type");
                if(contentType != null)
                    mimeType = contentType.ToString();
            }
            return mimeType;
        }
