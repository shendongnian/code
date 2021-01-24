    private void FrmMain_Load(object sender, EventArgs e)
    {
        tabView.TabPages.Clear();
        toolTip.ShowAlways = true;
        toolTip.SetToolTip(btnACust, "Add customer");
        toolTip.SetToolTip(btnRCust, "Remove customer");
        toolTip.SetToolTip(btnSrch, "Search for an item");
        toolTip.SetToolTip(btnRef, "Refresh search criteria and data");
        toolTip.SetToolTip(btnEdit, "Edit selected item");
        toolTip.SetToolTip(btnDel, "Delete selected item");
        toolTip.SetToolTip(btnSell, "Add item to cart");
        toolTip.SetToolTip(btnReg, "Sell item/s");
        toolTip.SetToolTip(btnCRef, "Refresh search criteria and data");
        toolTip.SetToolTip(btnUpd, "Update item");
        toolTip.SetToolTip(btnUndo, "Reset to default values");
        toolTip.SetToolTip(btnECan, "Cancel all changes and close");
        dataGridSales.Columns[3].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-PH");
        dataGridSales.Columns[3].DefaultCellStyle.Format = String.Format("C2");
        dataGridSales.Columns[3].ValueType = typeof(Double);
        dataGridSales.Columns[4].Visible = false;
        lblTimeDate.Text = "Date: " + System.DateTime.Now.ToShortDateString();
        dateTimeToday.Value = System.DateTime.Now;
    }
