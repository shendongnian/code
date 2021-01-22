     public static bool HasWritePermissionOnDir(string path)
        {
            var result = false;
            var accessControlList = Directory.GetAccessControl(path );
            var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
            for (var i = 0; i < accessRules.Count; i++)
            {
                var rule = accessRules[i] as FileSystemAccessRule; 
                if(rule==null) continue;
                var rights = rule.FileSystemRights;
                if ((FileSystemRights.Write & rights) == FileSystemRights.Write)
                {
                    result = true;
                }
            }
            return result;
        }
