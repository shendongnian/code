    [XmlType("HardDrive")]
    public class DriveData
    {
        public string Model { get; set; }
        public string Type { get; set; }
        public int SizeGB { get; set; }
        public string SerialNumber { get; set; }
        public bool IsOK { get; set; }
    }
    class Program
    {
        static List<DriveData> DiskDrives  { get; set; } = new List<DriveData>();
        static void Main(string[] args)
        {
            DiskDrives.Add(new DriveData { Model = "Seagate1", Type = "SATA", SizeGB = 999 });
            DiskDrives.Add(new DriveData { Model = "Seagate2", Type = "SATA", SizeGB = 777 });
            XmlSerializer serializer = new XmlSerializer(typeof(List<DriveData>), new XmlRootAttribute("HardDrives"));
            FileStream xmlFile = File.Create("DiskDrives.xml");
            serializer.Serialize(xmlFile, DiskDrives);
            xmlFile.Close();
            Console.Read();
        }      
    }
