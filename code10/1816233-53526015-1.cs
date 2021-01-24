        public string GetAttributeValueAtSubElement()
        {
            string rv = string.Empty;
            IEnumerable<XAttribute> attribs =
            from el in _XML_Elem.Descendants(_NameSpace + "path")  also?
                select el.Attribute("d");
            if (attribs.Count() > 0 && attribs.First<XAttribute>().Value.Contains("M0,")
                && attribs.First<XAttribute>().Value.Contains("z"))
                rv = attribs.First<XAttribute>().Value; 
            return rv;
        }
