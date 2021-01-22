            string xml;   //this is what i will send
            var stream = new MemoryStream();
            using (var writer = new XmlTextWriter(stream, new UTF8Encoding()))
            {
                documentoDaInviare.Save(writer);
                writer.Flush();
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    xml = reader.ReadToEnd();
                }
            }
