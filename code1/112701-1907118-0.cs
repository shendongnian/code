    public override void OnDataArrival()
    {
        // here on background thread
        this.Invoke((MethodInvoker)delegate {
            // here on UI thread
            //TODO: update DataTable
        });
    }
