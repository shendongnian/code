       Dim storageFile As IsolatedStorageFile
        If Request("storage") = "user" Then
            storageFile = IsolatedStorageFile.GetUserStoreForAssembly()
        Else
            storageFile = IsolatedStorageFile.GetMachineStoreForAssembly()
        End If
        Response.Write(storageFile.GetType.GetField("m_RootDir", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance).GetValue(storageFile).ToString())
