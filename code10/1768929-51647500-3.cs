    private string GetCellValue(Cell theCell)
        {
            string cellValue = string.Empty;
            string returnValue = string.Empty;
            if (theCell != null)
            {
                cellValue = theCell.InnerText;
                if (theCell.DataType != null)
                {
                    #region Type Switch
                    switch (theCell.DataType.Value)
                    {
                        case CellValues.Boolean:
                            switch (cellValue)
                            {
                                case "0":
                                    returnValue = "FALSE";
                                    break;
                                default:
                                    returnValue = "TRUE";
                                    break;
                            }
                            break;
                        case CellValues.Number:
                            returnValue = cellValue.ToString();
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
            }
            else
            {
                //HACK if the cell is null we add an empty space
                returnValue = null;
            }
            return returnValue;
        }
