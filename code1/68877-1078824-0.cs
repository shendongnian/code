    private void HighlightRows()
    {
        DataGridViewCellStyle GreenStyle = null;
    
        if (this.dgridv.DataSource != null)
        {
            RedCellStyle = new DataGridViewCellStyle();
            RedCellStyle.BackColor = Color.Red;
    
            for (Int32 i = 0; i < this.dgridv.Rows.Count; i++)
            {
                if (((DataTable)this.dgridv.DataSource).Rows[i]["col_name"].ToString().ToUpper() == "NO")
                {
                    this.dgridv.Rows[i].DefaultCellStyle = RedCellStyle;
                    continue;
                }
            }
        }
    }
