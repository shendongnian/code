    private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
    {
        if (e.Column == colVehicle_FahrzeugartID && e.ListSourceRowIndex >= 0)
        {
            int rowHandle = gridViewList.GetRowHandle(e.ListSourceRowIndex);
            object cellValue = gridViewList.GetRowCellValue(rowHandle, "Vehicle_FahrzeugartID");
            this.clsFahrzeugart.ReadFromDb((int)cellValue);
            if (this.clsFahrzeugart.Systemstatus == 11)
            {
                e.DisplayText = "Deleted...";
            }
        }
    }
