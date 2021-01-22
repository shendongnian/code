    string[] MainDirs = Directory.GetDirectories(DirString);
    
    for (int i = 0; i < MainDirs.Length; i++)
    {
        using (ZipFile zip = new ZipFile())
        {
            zip.UseUnicodeAsNecessary = true;
            zip.AddDirectory(MainDirs[i]);
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
            zip.Comment = "This zip was created at " + System.DateTime.Now.ToString("G");
            zip.Save(string.Format("test{0}.zip", i));   
        }
    }
