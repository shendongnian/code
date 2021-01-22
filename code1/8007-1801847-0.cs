               string directoryPath = "C:\\XYZ"; //folderBrowserDialog.SelectedPath;
               bool isWriteAccess = false;
               try
               {
                  AuthorizationRuleCollection collection = Directory.GetAccessControl(directoryPath).GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                  foreach (FileSystemAccessRule rule in collection)
                  {
                     if (rule.AccessControlType == AccessControlType.Allow)
                     {
                        isWriteAccess = true;
                        break;
                     }
                  }
               }
               catch (UnauthorizedAccessException ex)
               {
                  isWriteAccess = false;
               }
               catch (Exception ex)
               {
                  isWriteAccess = false;
               }
               if (!isWriteAccess)
               {
                 //handle notifications                 
               }
