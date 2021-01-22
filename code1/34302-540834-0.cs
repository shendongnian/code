        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = row.Cells[0].Controls[0] as CheckBox;
                if (chk != null && chk.Checked)
                {
                    // ...
                }
            }
        }
