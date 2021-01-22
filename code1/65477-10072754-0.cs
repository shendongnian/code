    private static void Unzip()
    {
        var zipFilePath = "c:\\myfile.zip";
        var tempFolderPath = "c:\\unzipped";
        using (Package pkg = ZipPackage.Open(zipFilePath, FileMode.Open, FileAccess.Read))
        {
            foreach (PackagePart part in pkg.GetParts())
            {
                var target = Path.GetFullPath(Path.Combine(tempFolderPath, part.Uri.OriginalString.TrimStart('/')));
                var targetDir = target.Remove(target.LastIndexOf('\\'));
                if (!Directory.Exists(targetDir))
                    Directory.CreateDirectory(targetDir);
                using (Stream source = part.GetStream(FileMode.Open, FileAccess.Read))
                {
                    CopyStream(source, File.OpenWrite(target));
                }
            }
        }
    }
    private static void CopyStream(Stream input, Stream output)
    {
        byte[] buffer = new byte[4096];
        int read;
        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            output.Write(buffer, 0, read);
        }
    } 
