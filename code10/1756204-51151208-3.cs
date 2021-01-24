    public static RepositoryItemTextEdit NullEdit
    {
        get
        {
            if (_nullEdit == null)
            {
                _nullEdit = new RepositoryItemTextEdit();
                _nullEdit.ReadOnly = true;
                _nullEdit.AllowFocused = false;
                _nullEdit.CustomDisplayText += (sender, args) => args.DisplayText = "";
            }
            return _nullEdit;
        }
    }
    private void GridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
    {
        if(IsDisabled(e.RowHandle,e.Column))
        {
            e.RepositoryItem = NullEdit;
        }
    }
