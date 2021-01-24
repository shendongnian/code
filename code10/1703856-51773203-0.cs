    private void button2_Click(object sender, EventArgs e)
    {
        ADFScan  scanner = new ADFScan();
        scanner.Scanning += new EventHandler<WiaImageEventArgs>(_scanner_Scanning);
        scanner.ScanComplete += new EventHandler(_scanner_ScanComplete);
        ScanColor selectedColor = ScanColor.BlackWhite;
        int dpi = 300;//some scanners have a problem if you set a lower DPI
        scanner.BeginScan(selectedColor,dpi );
        //ADFScan will now raise a Scanning event for EACH document scanned.
        //then scan complete once there are no more documents to scan.
    }
    void _scanner_ScanComplete(object sender, EventArgs e)
    {
        MessageBox.Show("Scan Complete");
    }
    void _scanner_Scanning(object sender, WiaImageEventArgs e)
    {//e.ScannedImage is a System.Drawing.Image
        e.ScannedImage.Save(filename, ImageFormat.Jpeg);//FILES ARE RETURNED AS BITMAPS
    }
