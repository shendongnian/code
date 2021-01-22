    public void ColourChange()
        {
            DataGridViewCellStyle RedCellStyle = null;
            RedCellStyle = new DataGridViewCellStyle();
            RedCellStyle.ForeColor = Color.Red;
            DataGridViewCellStyle GreenCellStyle = null;
            GreenCellStyle = new DataGridViewCellStyle();
            GreenCellStyle.ForeColor = Color.Green;
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                if (dgvr.Cells["FollowedUp"].Value.ToString().Contains("No"))
                {
                    dgvr.DefaultCellStyle = RedCellStyle;
                }
                if (dgvr.Cells["FollowedUp"].Value.ToString().Contains("Yes"))
                {
                    dgvr.DefaultCellStyle = GreenCellStyle;
                }
            }
        }
