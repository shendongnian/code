    if (result.Equals(newPrevious) || result.Equals("T") && yIndex < table.GetLength(1))
            {
                if (counterForRow == 1)
                {
                    yIndex = 0;
                    counterForTie++;
                    table[xIndex, yIndex] = result;
                    counterForRow++;
                }
                else { 
                    yIndex += 1;
                    counterForTie++;
                    table[xIndex, yIndex] = result;
                }
            }
            else if (result.Equals(newPrevious) && previous.Equals("T") && yIndex < table.GetLength(1))
            {
                yIndex += 1;
                counterForTie++;
                table[xIndex, yIndex] = result;
            }
            else
            {
                if (justMoveToY == 1 && counterForRow == 1)
                {
                    xIndex = 0;
                    yIndex = 0;
                    table[xIndex, yIndex] = result;
                    justMoveToY++;
                    counterForRow++;
                    
                }
                else if (justMoveToY == 1)
                {
                    xIndex = 0;
                    yIndex += 1;
                    table[xIndex, yIndex] = result;
                    justMoveToY++;
                }
                else
                {
                    xIndex += 1;
                    yIndex = 0;
                    table[xIndex, yIndex] = result;
                    counterForTie = 0;
                }
            }
