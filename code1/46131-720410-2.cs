        static void Strip(XElement el, XNamespace ns) {
            List<XElement> remove = new List<XElement>();
            foreach (XElement child in el.Elements()) {
                if (child.Name.Namespace == ns) {
                    remove.Add(child);
                } else {
                    Strip(child, ns);
                }
            }
            remove.ForEach(child => child.Remove());
            foreach (XAttribute child in
                (from a in el.Attributes()
                 where a.Name.Namespace == ns
                 select a).ToList()) {
                child.Remove();
            }
        }
