            int count = 0;
            E.Range excelRange = sheet.UsedRange;
            object[,] valueArray = (object[,])excelRange.get_Value(E.XlRangeValueDataType.xlRangeValueDefault);
            if (valueArray.GetUpperBound(0) > 1)
            {
                for (int i = 0; i < valueArray.GetUpperBound(0) + 2; i++)
                {
                    if (valueArray[i + 2, 1] == null)
                        break;
                    else
                        count++;
                }
            }
