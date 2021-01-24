    <note>
    <to>Tove</to>
    <from>Jani</from>
    <heading>Hello</heading>
    <heading>Hello2</heading>
    <body>Don't forget me this weekend!</body>
    </note>
    
    
    
    
    
    <note>
    <to>Tove</to>
    <from>Jani</from>
    <heading><subhead>Data</subhead></heading>
    <body>Don't forget me this weekend!</body>
    </note>
    
    
    
    
        [XmlRoot(ElementName = "note")]
        public class Note
        {
            [XmlElement(ElementName = "to")]
            public string To { get; set; }
            [XmlElement(ElementName = "from")]
            public string From { get; set; }
            [XmlElement(ElementName = "heading")]
            public List<object> Heading { get; set; }
            [XmlElement(ElementName = "body")]
            public string Body { get; set; }
        }
