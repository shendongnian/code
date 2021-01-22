    static void Main(string[] args)
    {
    var drives = DriveInfo.GetDrives();
    foreach (DriveInfo info in drives)
    {
          Console.WriteLine("Name: {0}\nSize: {1}\nDrive Format: {2}", info.Name, info.TotalSize, info.DriveFormat);
    }
     Console.ReadLine();
    }
