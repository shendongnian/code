    private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
    {
        GridView View = sender as GridView;
        if (e.RowHandle >= 0) {
            string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["status"]);
            if (status == "Completed") {
                e.Appearance.BackColor = Color.IndianRed;   
            }
        }
    }
