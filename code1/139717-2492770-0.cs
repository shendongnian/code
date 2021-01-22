    public void WriteExcelDocument(string filename, string[,] values)
    {
        using (var writer = XmlWriter.Create(filename))
        {
            const string ss = "urn:schemas-microsoft-com:office:spreadsheet";
			writer.WriteProcessingInstruction("mso-application", "progid=\"Excel.Sheet\"");
            writer.WriteStartElement("ss", "Workbook", ss);
            writer.WriteStartElement("Worksheet", ss);
            writer.WriteAttributeString("Name", ss, "Sheet1");
            writer.WriteStartElement("Table", ss);
            for (var i = 0; i < values.GetLength(0); i++)
            {
                writer.WriteStartElement("Row", ss);
                for (var j = 0; j < values.GetLength(1); j++)
                {
                    writer.WriteStartElement("Cell", ss);
                    writer.WriteStartElement("Data", ss);
                    // Valid types are: Number, DateTime, Boolean, String, Error.
                    // To keep the example simple, I'm just doing strings.
                    writer.WriteAttributeString("Type", ss, "String");
                    // If the cell contains a boolean, be sure to write "0" or "1" here, not
                    // "false" or "true".  Again, I'm just doing strings, so it doesn't matter.
                    writer.WriteString(values[i, j]);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
