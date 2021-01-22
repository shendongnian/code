    if (!excelworksheet.Cells[CurTaskNode.DATA_MIN_ROW + minRow, CurTaskNode.DATA_MIN_COL + 1].Locked )
    {
      excelworksheet.Cells[CurTaskNode.DATA_MIN_ROW + minRow, CurTaskNode.DATA_MIN_COL + minCol] = values[iValueIndex];
      iValueIndex++;
    }
    else
    {
      excelworksheet.Cells[CurTaskNode.DATA_MIN_ROW + minRow, CurTaskNode.DATA_MIN_COL + minCol] = values.SLICE(iValueIndex);
      iValueIndex++;
    }
                                                           
