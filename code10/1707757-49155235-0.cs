            for (int col = 0; col < inSectionTable.Columns.Count; col++)
            {
                if (inSectionTable.Rows.Count <= numHeaderRows)
                {
                    nextEmptyColumnId = 0;
                    break;
                }
                else
                {
                    nextEmptyColumnId = inSectionTable.Rows[numHeaderRows].Cells.Count;
                    break;
                }
            }
