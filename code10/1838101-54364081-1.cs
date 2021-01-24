            private void tbx_champ_Cpt_TextChanged(object sender, EventArgs e)
        {
            if (tbx_champ_Cpt.Text.ToString() == "")
            {
                for (int i = 0; i < dgv_DetailComptes.Rows.Count - 1; i++)
                {
                    dgv_DetailComptes.Rows[i].Selected = false;
                }
            }
            else
            {
                tbx_champ_Cpt.SelectionStart = tbx_champ_Cpt.Text.Length;
                tbx_champ_Cpt.Text = tbx_champ_Cpt.Text.ToString().ToUpper();
                DataTable d = (DataTable)dgv_DetailComptes.DataSource;
                String text = tbx_champ_Cpt.Text.ToString();
                DataRow[] row = d.Select("Champ like '%" + text + "%'");
                List<int> listeIndex = new List<int>();
                for (int i = 0; i < dgv_DetailComptes.Rows.Count - 1; i++)
                {
                    foreach (DataRow r in row)
                    {
                        if (((DataRowView)dgv_DetailComptes.Rows[i].DataBoundItem).Row == r)
                        {
                            dgv_DetailComptes.Rows[i].Selected = true;
                            listeIndex.Add(i);
                        }
                        else if (!listeIndex.Contains(i))
                        {
                            dgv_DetailComptes.Rows[i].Selected = false;
                        }
                    }
                }
            }
            if (dgv_DetailComptes.SelectedRows.Count != 0)
            {
            dgv_DetailComptes.FirstDisplayedScrollingRowIndex = dgv_DetailComptes.SelectedRows[0].Index;
            }
        }
