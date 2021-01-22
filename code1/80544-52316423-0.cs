        public static Range GetUsedPartOfRange(this Range range)
        {
            Excel.Range beginCell = range.Cells[1, 1];
            Excel.Range endCell = range.Cells[range.Rows.Count, range.Columns.Count];
            // Excel 2016 - has to be search by rows, performance of by column is poor
            // not sure if this holds for other versions.
            if (!beginCell.HasFormula)
            {
                beginCell = range.Find(
                    "*",
                    beginCell,
                    XlFindLookIn.xlFormulas,
                    XlLookAt.xlPart,
                    XlSearchOrder.xlByRows,
                    XlSearchDirection.xlNext,
                    false);
            }
            if (!endCell.HasFormula)
            {
                endCell = range.Find(
                "*",
                endCell,
                XlFindLookIn.xlFormulas,
                XlLookAt.xlPart,
                XlSearchOrder.xlByRows,         
                XlSearchDirection.xlPrevious,
                false);
            }
            if (null == endCell || null == beginCell)
                return null;
            if (endCell.Row < beginCell.Row)
            {
                // complete lack of trust in excel...
                Excel.Range temp = beginCell;
                beginCell = endCell;
                endCell = temp;
            }
            Excel.Range finalRng = range.Worksheet.Range[beginCell, endCell];
            return finalRng;
        }
    }
