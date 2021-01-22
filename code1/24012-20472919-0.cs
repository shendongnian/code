    public void WriteExcelAutoStyledCell(object value)
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");
            string newValue = string.Empty;
            try
            {
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
                    newValue = CheckXmlCompatibleValues(value.ToString()).ToString();
                    WriteExcelStyledCell(newValue, CellStyle.General);
                }
            }
            catch (Exception thisException)
            {
                throw new InvalidOperationException(thisException.Message.ToString());
            }
        }
