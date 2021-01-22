     <WebMethod()> _
        Public Function ChangePermission()
            Dim file As String = "C:\Pictures"
            Dim fs As FileSecurity = System.IO.File.GetAccessControl(file)
            Dim owner As NTAccount = CType(fs.GetOwner(GetType(NTAccount)), NTAccount)
    
            Dim usergroup As AuthorizationRuleCollection = fs.GetAccessRules(True, True, (GetType(System.Security.Principal.NTAccount)))
            Try
                For Each Rule As FileSystemAccessRule In usergroup
                    RemoveAllowPermission(file, Rule.IdentityReference.Value, "FullControl")
                  Next
            Catch ex As Exception
    Return ("Error")
            End Try
        End Sub
    Return 0
    End Class
