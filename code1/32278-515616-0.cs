        protected void DetailsView1_DataBound(object sender, EventArgs e)
        {
            DetailsView dv = (DetailsView)sender;
            if (dv.DataItemCount > 0)
            {
                DataRowView data = (DataRowView)dv.DataItem;
                bool isFixed = (bool)data["IsFixed"];
                if (isFixed)
                {
                    dv.Rows[2].Enabled = false;
                    dv.Rows[6].Enabled = false;
                }
            }
        }
