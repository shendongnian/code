            List<AssemblyBO> list = new List<AssemblyBO>();
            list.Add(new AssemblyBO());
            list.Add(new AssemblyBO() { DisplayName = "Try", Identifier = "243242" });
            XDocument doc = new XDocument();
            SerializeParams<T>(doc, list);
            List<AssemblyBO> newList = DeserializeParams<AssemblyBO>(doc);
