    string xmlText1 = @"<PARM KEY=""K1"" VALUE=""V1""/>";
    string xmlText2 = @"<PARM><KEY>K2</KEY><VALUE>V2</VALUE></PARM>";
    [XmlRoot(ElementName = "PARM")]
    public class ParmInfo
    {
        [XmlAttribute("KEY")]
        public string ParmAttrKey { get; set; }
    
        [XmlAttribute("VALUE")]
        public string ParmAttrVal { get; set; }
    
        [XmlElement("KEY")]
        public string ParmEleKey { get; set; }
    
        [XmlElement("VALUE")]
        public string ParmEleVal { get; set; }
    
        public ParmInfo()
        {
    
        }
    
        public ParmInfo(string inpParmEleKey, string inpParmEleVal, string inpParmAttrKey, string inpParmAttrVal)
        {
            ParmEleKey = inpParmEleKey;
            ParmEleVal = inpParmEleVal;
            ParmAttrKey = inpParmAttrKey;
            ParmAttrVal = inpParmAttrVal;
        }
    }
