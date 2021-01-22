    using DevExpress.XtraGrid.Views.Grid;
     
     private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e) {
        GridView View = sender as GridView;
        if(e.RowHandle >= 0) {
           string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Category"]);
           if(category == "Beverages") {
              e.Appearance.BackColor = Color.Salmon;
              e.Appearance.BackColor2 = Color.SeaShell;
           }            
        }
     }
