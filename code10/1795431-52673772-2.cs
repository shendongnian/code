    public List<DataAttr> GetDataAttribute(XDocument xDocument)
        {
            var dataAttr = new List<DataAttr>();
            foreach (var route in xDocument.Descendants("RoutePoints"))
            {
                foreach (var point in route.Elements())
                {
                    if (point.HasElements)
                    {
                        dataAttr.AddRange(_getAttributeValues(point.Attributes()));
                    }
                }
            }
            return dataAttr;
        }
    
        private static IEnumerable<DataAttr> _getAttributeValues(IEnumerable<XAttribute> attributes)
        {
            return attributes.Select(x => new DataAttr()
            {
                Name = x.Name.LocalName,
                Value = x.Value
            });
        }
