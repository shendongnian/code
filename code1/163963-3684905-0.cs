    private void OnTrigger(object sender, TriggerEventArgs e)
    {
        if (e.NewState == e.PreviousState)
            return;
        // Pseudocode
        if (e.NewState == TriggerState.RELEASED)
        {
            myBarcodeReader.Actions.ToggleSoftTrigger();
            myBarcodeReader.Actions.Flush();
            myBarcodeReader.Actions.Disable();
        }
        else if (e.NewState == TriggerState.STAGE2)
        {
            // Prepare the barcode reader for scanning
            // This initializes various objects but does not actually enable the scanner device
            // The scanner device would still need to be triggered either via hardware or software
            myBarcodeReader.Actions.Enable();
            myBarcodeReader.Actions.Read(data);
            // Finally, turn on the scanner via software
            myBarcodeReader.Actions.ToggleSoftTrigger();
        }
    }
