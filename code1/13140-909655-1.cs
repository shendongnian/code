    protected override void LoadViewState(object savedState)
    {
        base.LoadViewState(savedState);
        if (!string.IsNullOrEmpty(CurrentUserControl))
            LoadDataTypeEditorControl(CurrentUserControl, panelFVE);
    }
