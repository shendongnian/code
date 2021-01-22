    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"C:\TempDir\");
    if (dir.Exists)
    {
        foreach (System.IO.FileInfo fi in dir.GetFiles())
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(fi.OpenRead());
            // do what you will....
            sr.Close();
        }
    }
