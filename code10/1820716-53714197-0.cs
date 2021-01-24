    public class SampleData
    {
        public SampleData()
        {
            this.Cells = new List<CellModel>();
        }
        public SampleData(params CellModel[] data) : this()
        {
            this.Cells.AddRange(data);
        }
        [XmlArrayItem("Cell")]
        public List<CellModel> Cells { get; set; }
        public string ToXml()
        {
            var ms = new System.IO.StringWriter();
            var settings = new XmlWriterSettings()
            {
                OmitXmlDeclaration = true,
                Indent = true,
                CloseOutput = true,
                NewLineOnAttributes = false,
            };
            var fs = XmlWriter.Create(ms, settings);
            var tool = new XmlSerializer(typeof(SampleData));
            tool.Serialize(fs, this);
            fs.Close();
            return ms.ToString();
        }
        public static SampleData FromXml(string xml)
        {
            var ms = new StringReader(xml);
            var fs = XmlReader.Create(ms);
            var tool = new XmlSerializer(typeof(SampleData));
            var data = tool.Deserialize(fs) as SampleData;
            return data;
        }
    }
    public struct CellModel
    {
        public string CellName { get; set; }
        public double CellAh { get; set; }
        public double CellNominalVoltage { get; set; }
        public double CellInternalResistance { get; set; }
        public double CylDeg05C25D { get; set; }
        public double CylDeg10C25D { get; set; }
        public double CylDeg20C25D { get; set; }
        public double CylDeg05C35D { get; set; }
        public double CylDeg10C35D { get; set; }
        public double CylDeg20C35D { get; set; }
        public double CylDeg05C45D { get; set; }
        public double CylDeg10C45D { get; set; }
        public double CylDeg20C45D { get; set; }
        public double CalDeg1stY25D { get; set; }
        public double CalDeg2ndY25D { get; set; }
        public double CalDeg3rdY25D { get; set; }
        public double CalDeg1stY35D { get; set; }
        public double CalDeg2ndY35D { get; set; }
        public double CalDeg3rdY35D { get; set; }
        public double CalDeg1stY45D { get; set; }
        public double CalDeg2ndY45D { get; set; }
        public double CalDeg3rdY45D { get; set; }
    }
