    Public Function GetTempDirectory() As String
        Dim mpath As String
        Do
            mpath = System.IO.Path.Combine(System.IO.Path.GetTempPath, System.IO.Path.GetRandomFileName)
        Loop While System.IO.Directory.Exists(mpath) Or System.IO.File.Exists(mpath)
        System.IO.Directory.CreateDirectory(mpath)
        Return mpath
    End Function
