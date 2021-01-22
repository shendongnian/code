        public static Range GetUsedPartOfRange(this Range range)
        {
            Excel.Range beginCell = range.Cells[1, 1];
            Excel.Range endCell = range.Cells[range.Rows.Count, range.Columns.Count];
            if (!beginCell.HasFormula)
            {
                var beginCellRow = range.Find(
                    "*",
                    beginCell,
                    XlFindLookIn.xlFormulas,
                    XlLookAt.xlPart,
                    XlSearchOrder.xlByRows,
                    XlSearchDirection.xlNext,
                    false);
                var beginCellCol = range.Find(
                    "*",
                    beginCell,
                    XlFindLookIn.xlFormulas,
                    XlLookAt.xlPart,
                    XlSearchOrder.xlByColumns,
                    XlSearchDirection.xlNext,
                    false);
                if (null == beginCellRow || null == beginCellCol)
                    return null;
                beginCell = range.Worksheet.Cells[beginCellRow.Row, beginCellCol.Column];
            }
            if (!endCell.HasFormula)
            {
                var endCellRow = range.Find(
                "*",
                endCell,
                XlFindLookIn.xlFormulas,
                XlLookAt.xlPart,
                XlSearchOrder.xlByRows,         
                XlSearchDirection.xlPrevious,
                false);
                var endCellCol = range.Find(
                    "*",
                    endCell,
                    XlFindLookIn.xlFormulas,
                    XlLookAt.xlPart,
                    XlSearchOrder.xlByColumns,
                    XlSearchDirection.xlPrevious,
                    false);
                if (null == endCellRow || null == endCellCol)
                    return null;
                endCell = range.Worksheet.Cells[endCellRow.Row, endCellCol.Column];
            }
            if (null == endCell || null == beginCell)
                return null;
            Excel.Range finalRng = range.Worksheet.Range[beginCell, endCell];
            return finalRng;
        }
    }
