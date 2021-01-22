    public string GetMIMEType(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);
            string fileExtension = fileInfo.Extension.ToLower();
            // direct mapping which is fast and ensures these extensions are found
            switch (fileExtension)
            {
                case "htm":
                case "html":
                    return "text/html";
                case "js":
                    return "text/javascript"; // registry may return "application/x-javascript"
            }
 
    
                // see if we can find extension info anywhere in the registry
    	//Note : there is not a ContentType key under ALL the file types , check Run --> regedit , then extensions !!!
    			
            RegistryPermission regPerm = new RegistryPermission(RegistryPermissionAccess.Read, @"\\HKEY_CLASSES_ROOT");
            // looks for extension with a content type
            RegistryKey rkContentTypes = Registry.ClassesRoot.OpenSubKey(fileExtension);
            if (rkContentTypes != null)
            {
                object key = rkContentTypes.GetValue("Content Type");
                if (key != null)
                    return key.ToString().ToLower();
            }
			
			  
            // looks for a content type with extension
			// Note : This would be problem if  multiple extensions associate with one content type.
            RegistryKey typeKey = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type");
            foreach (string keyname in typeKey.GetSubKeyNames())
            {
                RegistryKey curKey = typeKey.OpenSubKey(keyname);
                if (curKey != null)
                {
                    object extension = curKey.GetValue("Extension");
                    if (extension != null)
                    {
                        if (extension.ToString().ToLower() == fileExtension)
                        {
                            return keyname;
                        }
                    }
                }
            }
    
            return null;
        } 
