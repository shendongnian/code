    protected void btnPmtCalculation_Click(object sender, EventArgs e)
    {
        gvSpectrum.Columns[columnindex].Visible = false;
        //OR
        gvSpectrum.Columns["columnname"].Visible = false;
    }
