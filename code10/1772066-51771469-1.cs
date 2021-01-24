        public void HighlightNonUniformRowCells()
        {
            foreach (DataGridViewRow r in excelView_DGV.Rows)
            {
                r.DefaultCellStyle.BackColor = Color.White; // set to default until non-uniform value is detected
                for (int i = 0; i < r.Cells.Count - 1; i++)
                {
                    int j = i + 1;
                    if (!r.Cells[i].Value.Equals(r.Cells[j].Value))
                    {
                        if (i == 0 && r.Cells[j].Equals(r.Cells[j + 1])) r.Cells[i].Style.BackColor = Color.Red; // edge case - first cell contains the non-uniform value
                        else r.Cells[j].Style.BackColor = Color.Red;
                        break;
                    }
                }
            }
        }
