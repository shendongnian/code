             //trucate the text if it's to long..
            if (GridView1.Controls.Count != 0)
            {
                foreach (GridViewRow r in GridView1.Controls[0].Controls)
                {
                    foreach (TableCell tc in r.Controls)
                    {
                        if (tc.Text != "" && tc.Text.Length > 39)
                        {
                            tc.Text = tc.Text.Substring(0, 39) + " ...";
                        }
                    }
                }
            }
            // here is the where the magic happens :)
            if (GridView1.SelectedRow != null)
            {
                GridViewRow row = GridView1.SelectedRow;
                if (row.Cells.Count > 1)
                {
                    //Here I pick the p.keyID
                    SetOrderData(Convert.ToInt32(row.Cells[1].Text));
                    this.LabelDebug.Text = row.Cells[1].Text;
                }
            }
        }
