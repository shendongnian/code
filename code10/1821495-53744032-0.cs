    void Main()
    {
    	new BattInfo(new BattModel(){ BattName= "test"}).Save(@"tmp.xml");	
    	Console.Out.Write(BattInfo.Load(@"tmp.xml").Battery[0].BattName);
    }
    
    // Define other methods and classes here
    public class BattModel
    {
        public string BattName { get; set; } 
        public double NumCellSeries { get; set; }
        public double NumCellParallel { get; set; }
        public double CelltoPackResistanceSum { get; set; }
        public double BattThermalResistance { get; set; }
        public double BattHeatCapacity { get; set; }
    
    }
    
    public class BattInfo
    {
        [XmlElement("Battery")]
        public List<BattModel> Battery { get; set; }
    
        public BattInfo()
        {
            this.Battery = new List<BattModel>();
        }
        public BattInfo(params BattModel[] data) : this()
        {
            this.Battery.AddRange(data);
        }
        public void Save(string filename)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(filename, settings);
            XmlSerializer serializer = new XmlSerializer(typeof(BattInfo));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(writer, this,ns);
            writer.Flush();
            writer.Close();
        }
        public static BattInfo Load(string filename)
        {
            XmlReader reader = XmlReader.Create(filename);
            XmlSerializer serializer = new XmlSerializer(typeof(BattInfo));
            return (BattInfo)serializer.Deserialize(reader);
        }
    } 
