        Public Overrides Sub Commit(ByVal savedState As System.Collections.IDictionary)
            MyBase.Commit(savedState)
            Dim directoryOfMSI As String = IO.Path.GetDirectoryName(Context.Parameters("InstallerPath"))
    
            'Do your work here
            '...
        End Sub
