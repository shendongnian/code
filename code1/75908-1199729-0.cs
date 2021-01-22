    private void processControl_SetActive(object sender, CancelEventArgs e)
    {
        this.VisibleChanged += processControl_VisibleChanged;
    }
    void processControl_VisibleChanged(object sender, EventArgs e)
    {
        //Should only be called when everything is fully loaded and visible on the form.
        //Application.DoEvents()  -> actually bad idea!!
        BeginInvoke(new MethodInvoker(AddStuffToTextBox));
    }
