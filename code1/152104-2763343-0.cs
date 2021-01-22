    void Background_Method(object sender, DoWorkEventArgs e)
    {
        // ... time consuming stuff...
        // call back to the window to do the UI-manipulation
        this.BeginInvoke(new MethodInvoker(delegate {
            TreeView tv = new TreeView();
            // etc, manipulate
        }));
    }
