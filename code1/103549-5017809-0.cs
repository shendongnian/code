            DataTable dtResult = new DataTable();
            int nRows = ws.Rows.Count;
            int nCols = 3;//change this according to number of columns in your sheet, for some reason ws.columns.count returns 0
            for (int i = 0; i < nCols ; i++)
                dtResult.Columns.Add();
            for (int i = 0; i < nRows; i++)
            {
                if (ws.Cells[i, 0].Value != null)
                    dtResult.Rows.Add(ws.Cells[i, 0].Value.ToString(), ws.Cells[i, 1].Value.ToString(), ws.Cells[i, 2].Value.ToString());
            }
            return dtResult;
