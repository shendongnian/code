    public class ExcelWriter : IDisposable
    {
        private XmlWriter _writer;
        public enum CellStyle { General, Number, Currency, DateTime, ShortDate };
        public void WriteStartDocument()
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");
            
            _writer.WriteProcessingInstruction("mso-application", "progid=\"Excel.Sheet\"");
            _writer.WriteStartElement("ss", "Workbook", "urn:schemas-microsoft-com:office:spreadsheet");
             WriteExcelStyles();
       }
        public void WriteEndDocument()
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");
            _writer.WriteEndElement();
        }
        private void WriteExcelStyleElement(CellStyle style)
        {
            _writer.WriteStartElement("Style", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteAttributeString("ID", "urn:schemas-microsoft-com:office:spreadsheet", style.ToString());
            _writer.WriteEndElement();
        }
        private void WriteExcelStyleElement(CellStyle style, string NumberFormat)
        {
            _writer.WriteStartElement("Style", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteAttributeString("ID", "urn:schemas-microsoft-com:office:spreadsheet", style.ToString());
            _writer.WriteStartElement("NumberFormat", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteAttributeString("Format", "urn:schemas-microsoft-com:office:spreadsheet", NumberFormat);
            _writer.WriteEndElement();
            _writer.WriteEndElement();
        }
        private void WriteExcelStyles()
        {
            _writer.WriteStartElement("Styles", "urn:schemas-microsoft-com:office:spreadsheet");
            WriteExcelStyleElement(CellStyle.General);
            WriteExcelStyleElement(CellStyle.Number, "General Number");
            WriteExcelStyleElement(CellStyle.DateTime, "General Date");
            WriteExcelStyleElement(CellStyle.Currency, "Currency");
            WriteExcelStyleElement(CellStyle.ShortDate, "Short Date");
            _writer.WriteEndElement();
        }
        public void WriteStartWorksheet(string name)
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");
            _writer.WriteStartElement("Worksheet", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteAttributeString("Name", "urn:schemas-microsoft-com:office:spreadsheet", name);
            _writer.WriteStartElement("Table", "urn:schemas-microsoft-com:office:spreadsheet");
        }
        public void WriteEndWorksheet()
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");
            _writer.WriteEndElement();
            _writer.WriteEndElement();
        }
        public ExcelWriter(string outputFileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            _writer = XmlWriter.Create(outputFileName, settings);
        }
        public void Close()
        {
            if (_writer == null) throw new InvalidOperationException("Already closed.");
            _writer.Close();
            _writer = null;
        }
        public void WriteExcelColumnDefinition(int columnWidth)
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");
            _writer.WriteStartElement("Column", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteStartAttribute("Width", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteValue(columnWidth);
            _writer.WriteEndAttribute();
            _writer.WriteEndElement();
        }
        public void WriteExcelUnstyledCell(string value)
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");
            _writer.WriteStartElement("Cell", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteStartElement("Data", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "String");
            _writer.WriteValue(value);
            _writer.WriteEndElement();
            _writer.WriteEndElement();
        }
        public void WriteStartRow()
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");
            _writer.WriteStartElement("Row", "urn:schemas-microsoft-com:office:spreadsheet");
        }
        public void WriteEndRow()
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");
            _writer.WriteEndElement();
        }
        public void WriteExcelStyledCell(object value, CellStyle style)
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");
            _writer.WriteStartElement("Cell", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteAttributeString("StyleID", "urn:schemas-microsoft-com:office:spreadsheet", style.ToString());
            _writer.WriteStartElement("Data", "urn:schemas-microsoft-com:office:spreadsheet");
            switch (style)
            {
                case CellStyle.General:
                    _writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "String");
                    break;
                case CellStyle.Number:
                case CellStyle.Currency:
                    _writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "Number");
                    break;
                case CellStyle.ShortDate:
                case CellStyle.DateTime:
                    _writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "DateTime");
                    break;
            }
            _writer.WriteValue(value);
            //  tag += String.Format("{1}\"><ss:Data ss:Type=\"DateTime\">{0:yyyy\\-MM\\-dd\\THH\\:mm\\:ss\\.fff}</ss:Data>", value,
            _writer.WriteEndElement();
            _writer.WriteEndElement();
        }
        public void WriteExcelAutoStyledCell(object value)
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");
            //write the <ss:Cell> and <ss:Data> tags for something
            if (value is Int16 || value is Int32 || value is Int64 || value is SByte ||
                value is UInt16 || value is UInt32 || value is UInt64 || value is Byte)
            {
                WriteExcelStyledCell(value, CellStyle.Number);
            }
            else if (value is Single || value is Double || value is Decimal) //we'll assume it's a currency
            {
                WriteExcelStyledCell(value, CellStyle.Currency);
            }
            else if (value is DateTime)
            {
                //check if there's no time information and use the appropriate style
                WriteExcelStyledCell(value, ((DateTime)value).TimeOfDay.CompareTo(new TimeSpan(0, 0, 0, 0, 0)) == 0 ? CellStyle.ShortDate : CellStyle.DateTime);
            }
            else
            {
                WriteExcelStyledCell(value, CellStyle.General);
            }
        }
        #region IDisposable Members
        public void Dispose()
        {
            if (_writer == null)
                return;
            _writer.Close();
            _writer = null;
        }
        #endregion
    }
