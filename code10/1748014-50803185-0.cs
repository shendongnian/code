	[XmlRoot("HardDrives")]
	public class DiskDrives
	{
		[XmlElement("HardDrive")]
		public List<DriveData> Drives { get; set; }
	}
