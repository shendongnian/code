          SpreadsheetDocument doc = SpreadsheetDocument.Open(fullFilePath, false) //read file
            WorkbookPart x = doc.WorkbookPart;
            OpenXmlReader reader = OpenXmlReader.Create(workbookPart.WorksheetParts.First());
            int totalRow = 0;
            while (reader.Read())//read excel file every tag
            {
                if (reader.ElementType == typeof(Row))//start to deal with data when meet row tag
                {
                    if (totalRow == 0)//i want to skip header row
                    {
                        totalRow++;
                        reader.ReadFirstChild();//start reading the child element of row tag
                        do
                        {
                            if (reader.ElementType == typeof(Cell))//start to deal with the data in cell
                            {
       
                             Cell cell = (Cell)reader.LoadCurrentElement();//load into the element
                             //you can get data if you need header info
                                }
                            } while (reader.ReadNextSibling());//read another sibling cell tag. it will stop until the last sibling cell.
                        }
                        else
                    {
                           
                        reader.ReadFirstChild();
                        do
                        {
                            if (reader.ElementType == typeof(Cell))
                            {
                               Cell cell = (Cell)reader.LoadCurrentElement();
                               var container = GetValue(x, cell);// because not every data will directly store in cell tag. I have to deal with some situation in the GetValue function.
                            }
                        }while (reader.ReadNextSibling());
                    }
                }
            }
            private string GetValue(WorkbookPart workbookPart, Cell cell)
            {
                var cellValue = cell.CellValue;
    
                string value = (cellValue == null) ? cell.InnerText : cellValue.InnerText;//get info in cell tag
                if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)//when info store in sharedstringtable you have to get info in there
                {
                    return workbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
                }
                return value;
            }
