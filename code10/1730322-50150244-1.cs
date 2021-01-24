    if (table.GetLength(0) < xIndex)
                {
                    break;
                }
                if (previousValue.Equals(newPreviousValue) && yIndex < table.GetLength(1))
                {
                    yIndex += 1;
                    table[xIndex, yIndex] = previousValue;
                }
                else
                {
                    xIndex += 1;
                    yIndex = 0;
                    table[xIndex, yIndex] = previousValue;
                }
                newPreviousValue = previousValue;
