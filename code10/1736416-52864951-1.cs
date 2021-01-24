    public enum rotation : int
        {
            none,
            r90 = 5400000,
            r270 = -5400000,
            rNeg32 = -1920000
        }
     rotation rot = rotation.r90;
     XmlNamespaceManager nsm = chart.WorkSheet.Drawings.NameSpaceManager;
            XmlDocument doc = chart.ChartXml;
           
            XmlNode node = chart.ChartXml.SelectSingleNode(@"c:chartSpace/c:chart/c:plotArea/c:catAx", nsm);
            XmlNode InsertAfter = chart.ChartXml.SelectSingleNode(@"c:chartSpace/c:chart/c:plotArea/c:catAx/c:tickLblPos", nsm);
            XNamespace c = XNamespace.Get(nsm.LookupNamespace("c")); //  @"http://schemas.openxmlformats.org/drawingml/2006/chart";
            XNamespace a = XNamespace.Get(nsm.LookupNamespace("a")); // @"http://schemas.openxmlformats.org/drawingml/2006/main";
            XElement xml = new XElement(c + "txPr", new XAttribute(XNamespace.Xmlns + "c", c),
                                new XElement(a + "bodyPr", new XAttribute("rot", (int)rot), new XAttribute("vert", "horz"),new XAttribute(XNamespace.Xmlns + "a", a)),
                                new XElement(a + "lstStyle", new XAttribute(XNamespace.Xmlns + "a", a)),
                                new XElement(a + "p", new XAttribute(XNamespace.Xmlns + "a", a),
                                    new XElement(a + "pPr", 
                                        new XElement(a + "defRPr")
                                        ),
                                    new XElement(a +  "endParaRPr", new XAttribute ("lang", "en-US"))
                                    )
                                );
            
            
            using (XmlReader xmlReader = xml.CreateReader())
            {
               
               XmlNode  newNode = doc.ReadNode(xmlReader);
                //node.AppendChild(newNode);
                node.InsertAfter(newNode, InsertAfter);
            }
