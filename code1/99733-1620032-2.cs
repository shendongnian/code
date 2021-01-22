    public class InputFile
    {
        public String InputfileCommonProperty { get; set; }
    }
    public class ABCFile : InputFile
    {
        public String ABCSpecificProperty { get; set; }
    }
    public class XYZFile : InputFile
    {
        public String XYZSpecificProperty { get; set; }
    }
    public class InputFileHolder
    {
        public InputFileHolder()
        {
            InputFileList = new List<InputFile>();
        }
        [XmlArray]
        [XmlArrayItem(ElementName = "ABCFile", Type = typeof(ABCFile))]
        [XmlArrayItem(ElementName = "XYZFile", Type = typeof(XYZFile))]
        public List<InputFile> InputFileList { get; set; }
    }
