                if (tbx_champ_Cpt.Text.ToString() == "")
            {
                for (int i = 0; i < dgv_DetailComptes.Rows.Count - 1; i++)
                {
                    dgv_DetailComptes.Rows[i].Selected = false;
                } 
            }
            DataTable d = (DataTable)dgv_DetailComptes.DataSource;
            String text = tbx_champ_Cpt.Text.ToString();
            DataRow[] row = d.Select("Champ like '%"+text+"%'");
            for (int i = 0; i < dgv_DetailComptes.Rows.Count -1; i++)
            {
                if (((DataRowView)dgv_DetailComptes.Rows[i].DataBoundItem).Row == row.FirstOrDefault())
                {
                    dgv_DetailComptes.Rows[i].Selected = true;
                }
                else
                {
                    dgv_DetailComptes.Rows[i].Selected = false;
                }
            } 
