    // New scan message received
    private void RFIDScanReceived(RFID.Scan scan)
    {
        DispatcherHelper.CheckBeginInvokeOnUI(() => 
        {
            ScanInfoLabel = BitConverter.ToString(scan.UID);
        });
    }
