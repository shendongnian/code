    private delegate IList<MyObject> PopulateUiControl();
    private void myThread_DoWork(object sender, DoWorkEventArgs e) {
        PopulateUiControl myDelegate = FillUiControl;
        while(uiControl.InvokeRequired)
            uiControl.Invoke(myDelegate);
    }
    private IList<MyObject> FillUiControl() {
        uiControl.Items = myThreadResultsITems;
    }
