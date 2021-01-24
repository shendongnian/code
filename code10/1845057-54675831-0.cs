    private static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            //This process uses the OpenXML SDK to get individual cells values to populate the DataTable
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            string value = "";
            //One of the things that needed to be accounted for was empty cells
            try
            {
                value = cell.CellValue.InnerXml;
            }
            catch (Exception)
            {
                value = "";
            }
            //Checking to see if this string contains a decimal with values on either side
            if (Regex.IsMatch(value, regexpattern))
            {
                value = Math.Round(Double.Parse(value), 0, MidpointRounding.AwayFromZero).ToString();
            }
            //Setting cell data type right now just sets everything to strings
            //Later, the better option will be to work on the Date Conversions and Data Types here
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }
