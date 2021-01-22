        Dim d As New System.IO.DirectoryInfo(System.IO.Directory.GetCurrentDirectory())
        For Each f As System.IO.FileInfo In d.GetFiles("*.*proj")
            DTE.Solution.AddFromFile(f.FullName)
        Next
        DTE.Solution.Close(True)
