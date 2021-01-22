    gridView1.CustomRowCellEditForEditing += OnCustomRowCellEditForEditing;
    private void OnCustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
    {
        if (e.Column.FieldName != "MyFieldName") return;
            *code here*
            e.RepositoryItem.ReadOnly = true;
    }
