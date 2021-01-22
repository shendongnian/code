    public static void OnSelectionChanged(
      this DataGridView view,
      Action<List<DataGridViewRow>,List<DataGridViewRow>> handler) {
      var oldSelection = view.SelecetedRows.Cast<DataGridViewRow>.ToList();
      view.SelectedChanged += (sender,e)  {
        var newSelection = view.SelectedRows.Cast<DataGridViewRow>.ToList();
        handler(oldSelection,newSelection);
        oldSelection = newSelection;
      };
    }
