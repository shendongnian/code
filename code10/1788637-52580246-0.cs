        public void dgv_SetHeaderNames(DataGridView dgv, List<string> colNames, bool withColNum = false)
        {
            foreach (DataGridViewColumn dgvCol in dgv.Columns)
            {
                int currCol = dgvCol.Index;
                string colText = "";
                if (currCol >= colNames.Count)
                {
                    // if there are more columns than name we will use the column number, anyway.
                    colText = currCol.ToString();
                }
                else
                {
                    if (withColNum == true)
                    {
                        colText = currCol.ToString() + " - " + colNames[currCol];
                    }
                    else
                    {
                        colText = colNames[currCol];
                    }
                }
                dgv.Columns[currCol].HeaderText = colText;
            }
        }
