            var assembly = Assembly.GetExecutingAssembly();
            if (assembly != null)
            {
                var stream = assembly.GetManifestResourceStream("RootProjectNamespace.MyData.xml");
                if (stream != null)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(stream);
                }
            }
