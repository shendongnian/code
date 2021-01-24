     public static void ReplaceAllNegativeWithZeros(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        if (Convert.ToInt32(cell.Value.ToString()) < 0)
                        {
                            cell.Value = 0;
                        }
                    }
                }
            }
        }
