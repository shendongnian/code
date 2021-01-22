    // not a property, as there is no need to add a complex x-thread "get"
    public void SetIconVisible(bool isVisible) {
        if(this.InvokeRequired) {
            this.Invoke((MethodInvoker) delegate {
                myIcon.Visible = isVisible;
            });
        } else {
            myIcon.Visible = isVisible;
        }
    }
