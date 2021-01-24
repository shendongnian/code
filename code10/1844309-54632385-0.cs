    [Serializable]
    public struct s_mytype
    {
        public List<string> lines;
        [System.Xml.Serialization.XmlElementAttribute("Lines", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string[] Lines 
        { 
           get { return lines.ToArray(); } 
           set { lines.AddRange(value); } 
        }
    }
