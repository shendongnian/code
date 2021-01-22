        public class coordinate
        {
            [XmlAttribute]
            public int time;
            [XmlElement(ElementName="initial")]
            public string initial;
            [XmlElement(ElementName = "final")]
            public string final;
            public coordinate()
            {
                time = 0;
                initial = "";
                final = "";
            }
        }
        public class grid
        {
            [XmlElement(ElementName="coordinate", Type = typeof(coordinate))]
            public coordinate[] list;
            public grid()
            {
                list = new coordinate[0];
            }
        }     
