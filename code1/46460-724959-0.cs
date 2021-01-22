    foreach (string s in System.IO.Directory.GetFiles(sBasePath, "*.*"))
    {
        //We could do some filtering for example only adding .jpg or something
        oList.Add( System.IO.Path.GetFileName( s ));
    }
