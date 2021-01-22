    [Serializable]
    public class SpeedDial
    {
        static void Main()
        {
            XmlSerializer ser = new XmlSerializer(typeof(SpeedDial));
            SpeedDial foo = new SpeedDial { Value = "110", TextTR = "Yangin",
                TextEN = "Fire", IconId = "39" };
            ser.Serialize(Console.Out, foo);
        }
        public SpeedDial()
        {
            Text = new SpeedDialText();
        }
    
        [XmlElement("text"), EditorBrowsable(EditorBrowsableState.Never)]
        public SpeedDialText Text { get; set; }
    
        public string Value { get; set; }
        [XmlIgnore]
        public string TextTR
        {
            get { return Text.Tr; }
            set { Text.Tr = value; }
        }
        [XmlIgnore]
        public string TextEN
        {
            get { return Text.En; }
            set { Text.En = value; }
        }
    
        public string IconId { get; set; }
    }
    [Serializable]
    public class SpeedDialText
    {
        [XmlElement("EN")]
        public string En { get; set; }
        [XmlElement("TR")]
        public string Tr { get; set; }
    }
