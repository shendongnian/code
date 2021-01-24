	[XmlRoot("Inventory")]
	public class Inventory
	{
        … more properties here…
		[XmlArray("HardDrives")]
		[XmlArrayItem("HardDrive")]
		public List<DriveData> Drives { get; set; }
	}
