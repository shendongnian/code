    string[] files = System.IO.Directory.GetFiles(sBasePath, "*.jpg")
    foreach (string s in files)
    {
        oList.Add( System.IO.Path.GetFileName( s ));
    }
