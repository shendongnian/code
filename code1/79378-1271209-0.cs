    Dim directoryEntry As DirectoryEntry = _
          New DirectoryEntry("LDAP://CN=users,DC=domanName,DC=com")
    Dim directorySearcher As DirectorySearcher = _
          New DirectorySearcher(directoryEntry, "(sAMAccountName=" & UserName & ")")
    Dim searchResult As SearchResult = directorySearcher.FindOne()
    If Not searchResult Is Nothing Then
        Dim userDirectoryEntry As DirectoryEntry = searchResult.GetDirectoryEntry
        userDirectoryEntry.RefreshCache(New String() {"tokenGroups"})
        ... etc ...
    End If
