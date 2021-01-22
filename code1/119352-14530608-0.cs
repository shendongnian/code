    
    private void cntrl_MethodParameters_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        //Init
        var dgv = (DataGridView)sender;
        int row = e.RowIndex;
        int col = e.ColumnIndex;
        //Validate Edit
        if ((row >= 0) && (col == cntrl_MethodParameters.Columns.IndexOf(cntrl_MethodParameters.Columns[MethodBuilderView.m_paramValueCol])))
        {
            string xPropertyName = (string)cntrl_MethodParameters[MethodBuilderView.m_paramNameCol, row].EditedFormattedValue;
            string xPropertyValue = (string)cntrl_MethodParameters[MethodBuilderView.m_paramValueCol, row].EditedFormattedValue;
            bool Validated = FactoryProperties.Items[xPropertyName].SetState(xPropertyValue);
            //Cancel Invalid Input
            if (!Validated)
            {
                dgv.CancelEdit();
            }
        }
        this.ActiveControl = null;
    }
