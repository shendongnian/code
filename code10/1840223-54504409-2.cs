     private void ComputerSelection_FormClosed(object sender, FormClosedEventArgs e)
            {
                for(int i = 0; i < compGridView.Rows.Count; i++)
                {
                    compGridView.Rows[i].Cells[0].Value = true;
                }
            }
