    private void radGvReviews_CellDoubleClick(object sender, GridViewCellEventArgs e)
    {
        GridViewComboBoxColumn combo = e.Row.Cells["ContractorID"] as GridViewComboBoxColumn;
        
        if (combo != null)
        {
            MessageBox.Show(combo.DisplayMember);
        }
    }
