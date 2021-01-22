    private void gridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
    {
        if (ConditionIsMet())
        {
            e.RepositoryItem = null;
        }
    }
