       class XmlMove
        {
            private List<XElement> elements { get; set; }
            private int index = -1;
            public XmlMove(XDocument doc, string elementName)
            {
                elements = doc.Descendants(elementName).ToList();
                index = 0;
            }
            public XElement GetNext()
            {
                if (index == -1 || index >= elements.Count - 1) return null;
                return elements[++index];
            }
            public XElement GetPrevious()
            {
                if (index <= 0 ) return null;
                return elements[--index];
            }
            public XElement GetCurrent()
            {
                if (index == -1) return null;
                return elements[index];
            }
        }
