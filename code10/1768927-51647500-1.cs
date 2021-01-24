    private string GetCellValue(Cell theCell, WorkbookPart workbookPart)
            {
                string value = string.Empty;
                if (theCell != null)
                {
    
                    value = theCell.InnerText;
    
                    // If the cell represents a numeric value, you are done. 
                    // For dates, this code returns the serialized value that 
                    // represents the date. The code handles strings and Booleans
                    // individually. For shared strings, the code looks up the 
                    // corresponding value in the shared string table. For Booleans, 
                    // the code converts the value into the words TRUE or FALSE.
    
                    if (theCell.DataType != null)
                    {
                        #region Type Switch
                        switch (theCell.DataType.Value)
                        {
                            case CellValues.SharedString:
                                // For shared strings, look up the value in the shared 
                                // strings table.
                                var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                                // If the shared string table is missing, something is 
                                // wrong. Return the index that you found in the cell.
                                // Otherwise, look up the correct text in the table.
                                if (stringTable != null)
                                {
                                    value = stringTable.SharedStringTable.
                                      ElementAtOrDefault(int.Parse(value)).InnerText;
                                }
                                break;
    
                            case CellValues.Boolean:
                                switch (value)
                                {
                                    case "0":
                                        value = "FALSE";
                                        break;
                                    default:
                                        value = "TRUE";
                                        break;
                                }
    
                                break;
                            case CellValues.Number:
    
                                break;
                            case CellValues.Error:
                                break;
                            case CellValues.String:
    
                                break;
                            case CellValues.InlineString:
    
                                break;
                            case CellValues.Date:
    
                                break;
                            default:
                                break;
    
                        }
                        #endregion
    
                    }
                    //else
                    //{
                    //    row.Add(value);
                    //}
                }
                else
                {
                    //HACK if the cell is null we add an empty space
                    value = null;
                }
                return value;
            }
