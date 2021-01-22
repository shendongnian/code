    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
        if (string.IsNullOrEmpty(GetCurrentColumnValue("BarcodeColumnName"))) {
            barcode.Visible = false;
            lblWarning.Visible = true;
        } else {
            barcode.Visible = true;
            lblWarning.Visible = false;
        }
    }
