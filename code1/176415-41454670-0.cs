using System.IO;
    foreach (DriveInfo drive in DriveInfo.GetDrives())
    {
    	if (drive.DriveType == DriveType.Removable)
    	{
    		Console.WriteLine(string.Format("({0}) {1}", drive.Name.Replace("\\",""), drive.VolumeLabel));
    	}
    }
