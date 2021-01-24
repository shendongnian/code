        public void HighlightNonUniformRows()
        {
            foreach (DataGridViewRow r in excelView_DGV.Rows)
            {
                r.DefaultCellStyle.BackColor = Color.White; // set to default until non-uniform value is detected
                for (int i = 0; i < r.Cells.Count - 1; i++)
                {
                    int j = i + 1;
                    if (!r.Cells[i].Value.Equals(r.Cells[j].Value))
                    {
                        r.DefaultCellStyle.BackColor = Color.Red; // or other desired highlight color
                        break;
                    }
                }
            }
        }
