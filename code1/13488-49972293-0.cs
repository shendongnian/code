        public static string GetExtendedFileProperty(string filePath, string propertyName)
        {
            string value = string.Empty;
            string baseFolder = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);
            //Method to load and execute the Shell object for Windows server 8 environment otherwise you get "Unable to cast COM object of type 'System.__ComObject' to interface type 'Shell32.Shell'"
            Type shellAppType = Type.GetTypeFromProgID("Shell.Application");
            Object shell = Activator.CreateInstance(shellAppType);
            Shell32.Folder shellFolder = (Shell32.Folder)shellAppType.InvokeMember("NameSpace", System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { baseFolder });
            //Parsename will find the specific file I'm looking for in the Shell32.Folder object
            Shell32.FolderItem folderitem = shellFolder.ParseName(fileName);
            if (folderitem != null)
            {
                for (int i = 0; i < short.MaxValue; i++)
                {
                    //Get the property name for property index i
                    string property = shellFolder.GetDetailsOf(null, i);
                    //Will be empty when all possible properties has been looped through, break out of loop
                    if (String.IsNullOrEmpty(property)) break;
                    //Skip to next property if this is not the specified property
                    if (property != propertyName) continue;    
                    //Read value of property
                    value = shellFolder.GetDetailsOf(folderitem, i);
                }
            }
            //returns string.Empty if no value was found for the specified property
            return value;
        }
