        using(MemoryStream ms = new MemoryStream()) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.CloseOutput = false;
            using (XmlWriter writer = XmlWriter.Create(ms, settings))
            {
                writer.WriteStartElement("xml");
                for (int i = 0; i < 15000; i++)
                {
                    writer.WriteElementString("value", i.ToString());
                }
                writer.WriteEndElement();
            }
            Console.WriteLine(ms.Length + " bytes");
            ms.Position = 0;
            int nodes = 0;
            Stopwatch watch = Stopwatch.StartNew();
            using (XmlReader reader = XmlReader.Create(ms))
            {
                while (reader.Read()) { nodes++; }
            }
            watch.Stop();
            Console.WriteLine("{0} nodes in {1}ms", nodes,
                watch.ElapsedMilliseconds);
        }
