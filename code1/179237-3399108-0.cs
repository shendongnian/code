    [Serializable()]
    public class Project
    {
        private List<string> _Kinds = new List<string>();
        public Project()
        {
            ExtractedElementsTable = new DataTable();
            ExtractedElementsTable.TableName = "Output";
        }
        public List<string> Kinds
        {
            get { return _Kinds; }
            set { _Kinds = value; }
        }
        [XmlElement("ExtractedElements")]
        public string ExtractedElementsXml
        {
            get
            {
                using (var writer = new StringWriter())
                {
                    this.ExtractedElementsTable.WriteXml(writer);
                    return writer.ToString();
                }
            }
            set
            {
                using (var reader = new StringReader(value))
                {
                    this.ExtractedElementsTable.ReadXml(reader);
                }
            }
        }
        [XmlIgnore]
        public DataTable ExtractedElementsTable { get; set; }
    }
