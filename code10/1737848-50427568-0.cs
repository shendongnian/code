    private void CLB_SHOW_HIDE_SelectedIndexChanged(object sender, EventArgs e)
        {
            int f = 0;
            string qry = "";
            for (int i = 0; i < CLB_SHOW_HIDE.Items.Count; i++)
            {
                if (CLB_SHOW_HIDE.GetItemChecked(i))
                {
                    if (f == 1)
                    {
                        qry = CLB_SHOW_HIDE.Items[i].ToString();
                        this.DGV_FEATURE.Columns[qry].Visible = true;
                    }
                    if (f == 0)
                    {
                        qry = CLB_SHOW_HIDE.Items[i].ToString();
                        f = 1;
                        this.DGV_FEATURE.Columns[qry].Visible = true;
                    }
                }
                else
                {
                    qry = CLB_SHOW_HIDE.Items[i].ToString();
                    this.DGV_FEATURE.Columns[qry].Visible = false;
                }
            }
        }
