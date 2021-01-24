        public virtual  XmlReader  ReadSubtree() {
            if (NodeType != XmlNodeType.Element) {
                throw new InvalidOperationException(Res.GetString(Res.Xml_ReadSubtreeNotOnElement));
            }
            return new XmlSubtreeReader(this);
        }
