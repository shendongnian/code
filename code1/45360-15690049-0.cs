        public override string ToString()
        {
            var doc = XDocument.Parse(this.ToXML());
            WalkElement(doc.Root);
            return doc.ToString( SaveOptions.None );
        }
        void WalkElement(XElement e)
        {
            var n = e.GetNamespaceOfPrefix("i");
            if (n != null)
            {
                var a = e.Attribute(n + "nil");
                if (a != null && a.Value.ToLower() == "true")
                    e.Remove();
            }
            foreach (XElement child in e.Elements().ToList())
                WalkElement(child);
        }
