        public static List<List<Cell>> ParseTable(XTextTable table)
        {
            XTableRows rows = table.getRows() as XTableRows;
            int rowCount = rows.getCount();
            int sum = GetTableColumnRelativeSum(table);
            // Temprorary store for column count of each row
            int[] colCounts = new int[rowCount];
            List<List<int>> matrix = new List<List<int>>(rowCount);
            for (int i = 0; i < rowCount; i++)
                matrix.Add(new List<int>());
            // Get column count for each row
            int maxColCount = 0;
            for (int rowNo = 0; rowNo < rowCount; rowNo++)
            {
                TableColumnSeparator[] sep = GetTableRowSeperators(rows, rowNo);
                colCounts[rowNo] = sep.Length + 1;
                if (maxColCount < colCounts[rowNo])
                    maxColCount = colCounts[rowNo];
                for (int j = 0; j < sep.Length; j++)
                    matrix[rowNo].Add(sep[j].Position);
                matrix[rowNo].Add(sum);
            }
            int[] curIndex = new int[rowCount];
            List<List<Cell>> results = new List<List<Cell>>(rowCount);
            for (int i = 0; i < rowCount; i++)
                results.Add(new List<Cell>());
            int curMinSep = matrix[0][0];
            do
            {
                curMinSep = matrix[0][curIndex[0]];
                for (int i = 0; i < rowCount; i++)
                    if (curMinSep > matrix[i][curIndex[i]]) curMinSep = matrix[i][curIndex[i]];
                for (int rowNo = 0; rowNo < rowCount; rowNo++)
                {
                    int col = curIndex[rowNo];
                    int lastIdx = results[rowNo].Count - 1;
                    if (curMinSep == matrix[rowNo][col])
                    {
                        if (colCounts[rowNo] > col + 1) curIndex[rowNo] = col + 1;
                        if (results[rowNo].Count > 0 &&
                            results[rowNo][lastIdx].Text.Count < 1 &&
                            results[rowNo][lastIdx].ColSpan > 0)
                        {
                            results[rowNo][lastIdx].ColSpan++;
                            results[rowNo][lastIdx].Text = GetCellText(table, rowNo, col);
                        }
                        else
                        {
                            results[rowNo].Add(new Cell(0, 0, GetCellText(table, rowNo, col)));
                        }
                    }
                    else
                    {
                        if (results[rowNo].Count > 0 &&
                            results[rowNo][lastIdx].Text.Count < 1)
                        {
                            results[rowNo][lastIdx].ColSpan++;
                        }
                        else
                        {
                            results[rowNo].Add(new Cell(1, 0));
                        }
                    }
                }
            } while (curMinSep < sum);
            return results;
        }
