    using (var zf = Ionic.Zip.ZipFile.Read(zipPath))
    {
        zf.ToList().ForEach(entry =>
        {
            entry.FileName = System.IO.Path.GetFileName(entry.FileName);
            entry.Extract(appPath);
        });
    }
