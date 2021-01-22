    private void radioButtonSortProgram_CheckedChanged(object sender, EventArgs e)
    
    {
    
        if (this.radioButtonSortProgramAlpha.Checked)
    
            this.view.PropertyComparers["Program"] = new CustomerProgramComparerAlpha();
    
        else if (this.radioButtonSortProgramRank.Checked)
    
            this.view.PropertyComparers["Program"] = new CustomerProgramComparerRank();
    
        else
    
            this.view.PropertyComparers.Remove("Program");
    
    }
 
