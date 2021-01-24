    protected void btnPmtCalculation_Click(object sender, EventArgs e)
    {
            foreach(DataControlField col in gvSpectrum.Columns)
            {
                if (col.HeaderText == "Email")
                    col.Visible = false;
    
            }
    }
