        private void SetRuntimeBinding(string path, string value)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(Path.Combine(path, "MyApp.exe.config"));
            }
            catch (FileNotFoundException)
            {
                return;
            }
            XmlNamespaceManager manager = new XmlNamespaceManager(doc.NameTable);
            manager.AddNamespace("bindings", "urn:schemas-microsoft-com:asm.v1");
            XmlNode root = doc.DocumentElement;
            XmlNode node = root.SelectSingleNode("//bindings:bindingRedirect", manager);
            if (node == null)
            {
                throw (new Exception("Invalid Configuration File"));
            }
            node = node.SelectSingleNode("@newVersion");
            if (node == null)
            {
                throw (new Exception("Invalid Configuration File"));
            }
            node.Value = value;
            doc.Save(Path.Combine(path, "MyApp.exe.config"));
        }
