        XmlWriterSettings settings = new XmlWriterSettings();
        settings.NewLineHandling = NewLineHandling.Entitize;
        settings.Indent = true;
        settings.IndentChars = "\t";
        
        StringBuilder sb = new StringBuilder();
        using (XmlWriter xw = XmlWriter.Create(sb, settings))
        {
            xw.WriteStartDocument();
            xw.WriteStartElement(_pluralCamelNotation);
            for (int i = 0; i < 3; i++)
            {
                xw.WriteStartElement(_singularCamelNotation);
                foreach (DataType dataType in _allDataTypes)
                {
                    xw.WriteElementString(dataType.ToString(),
                        dataType.GetDummyData());
                }
                xw.WriteEndElement();
            }
            xw.WriteEndElement();
            xw.WriteEndDocument();
            xw.Close();
        }
