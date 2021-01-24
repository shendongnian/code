    protected override void OnExecutedCommitEdit(ExecutedRoutedEventArgs e)
    {
        base.OnExecutedCommitEdit(e);
        BindingFlags bindingFlags = BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Instance;
        PropertyInfo editableItems = this.GetType().BaseType.GetProperty("EditableItems", bindingFlags);
        ((System.ComponentModel.IEditableCollectionView)editableItems.GetValue(this)).CommitEdit();
    }
