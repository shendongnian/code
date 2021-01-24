    using DevExpress.XtraGrid.Views.Grid;
    // ... 
    private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e) {
        GridView view = sender as GridView;
        if(view == null) return;
        if (e.Column == colCreatorID) {
            string text1 = view.GetRowCellDisplayText(e.RowHandle1, colCreatorID);
            string text2 = view.GetRowCellDisplayText(e.RowHandle2, colCreatorID);
            e.Merge = (text1 == text2);
            e.Handled = true;
        }
    }
