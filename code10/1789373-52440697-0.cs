    private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e){
    GridView view = sender as GridView;
    if (e.Column == colVehicle_FahrzeugartID && e.ListSourceRowIndex >= 0) {
        object cellValue = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Vehicle_FahrzeugartID");
        this.clsFahrzeugart.ReadFromDb((int)cellValue);
        if (this.clsFahrzeugart.Systemstatus == 11)
            e.DisplayText = "Deleted...";
    }
