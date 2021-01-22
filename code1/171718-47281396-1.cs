if (File.Exists(clogfile))
{
    Int64 fileSizeInBytes = new FileInfo(clogfile).Length;
    if (fileSizeInBytes > 5000000)
    {
        string path = Path.GetFullPath(clogfile);
        string filename = Path.GetFileNameWithoutExtension(clogfile);
        System.IO.File.Move(clogfile, Path.Combine(path, string.Format("{0}{1}.log", filename, DateTime.Now.ToString("yyyyMMdd_HHmmss"))));
    }
}
           
