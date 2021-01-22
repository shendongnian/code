    PrinterSettings printerSetting = new PrinterSettings();
    printerSetting.PrinterName = ddlPrinterName.SelectedItem.Text;
    using (var wic = WindowsIdentity.Impersonate(IntPtr.Zero))
    {
        if (!printerSetting.IsValid)
        {
            lblMsg.Text = "Server Printer is not valid.";
        }
        else
        {
            lblMsg.Text = "Success";
        }
        // Do the remainder of your printing stuff here, but beware that
        // your user context is different.
    }
