      string applicationDirectory = (
        from assembly in AppDomain.CurrentDomain.GetAssemblies()
        where assembly.CodeBase.EndsWith(".exe")
        select System.IO.Path.GetDirectoryName(assembly.CodeBase.Replace("file:///", ""))
        ).FirstOrDefault();
