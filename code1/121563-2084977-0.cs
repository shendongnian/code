    Public Function RemoveAllowPermission(ByVal filePath As String, ByVal username As String, ByVal power As String) 
    
            Dim dirinfo As DirectoryInfo = New DirectoryInfo(filePath)
    
            Dim dirsecurity As DirectorySecurity = dirinfo.GetAccessControl()
            dirsecurity.SetAccessRuleProtection(True, True)
            Select Case power
    
                Case "FullControl"
    
                    dirsecurity.RemoveAccessRuleAll(New FileSystemAccessRule(username, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow))
    
                    dirsecurity.RemoveAccessRuleAll(New FileSystemAccessRule(username, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow))
    
                    dirsecurity.RemoveAccessRuleAll(New FileSystemAccessRule(username, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow))
    
                Case "ReadOnly"
    
                    dirsecurity.RemoveAccessRuleAll(New FileSystemAccessRule(username, FileSystemRights.Read, AccessControlType.Allow))
    
                Case "Write"
    
                    dirsecurity.RemoveAccessRuleAll(New FileSystemAccessRule(username, FileSystemRights.Write, InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow))
    
                    dirsecurity.RemoveAccessRuleAll(New FileSystemAccessRule(username, FileSystemRights.Write, InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow))
    
                    dirsecurity.RemoveAccessRuleAll(New FileSystemAccessRule(username, FileSystemRights.Write, InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow))
    
                Case "Modify"
    
                    dirsecurity.RemoveAccessRuleAll(New FileSystemAccessRule(username, FileSystemRights.Modify, AccessControlType.Allow))
    
            End Select
    
            dirinfo.SetAccessControl(dirsecurity)
    
        End function
