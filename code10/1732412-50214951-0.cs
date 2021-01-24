    KeyEventHandler deleteHandler = (s, e) => {
        if (e.Key != Delete) { return; }
        if (Modifiers.HasFlag(Alt) || Modifiers.HasFlag(ModifierKeys.Control) || Modifiers.HasFlag(Shift)) { return; }
        e.Handled = true;
        var dg = s as DataGrid;
        var ifd = dg.SelectedItem as ImageFileDetails;
        ifd.ToDelete = !ifd.ToDelete;
        //even though INPC is implemented on ImageFileDetails, the changes aren't noticed by the
        //CollectionViewSource
        cvsCurrentImages.View.Refresh();
        cvsToDeleteImages.View.Refresh();
        dg.Focus();
    };
