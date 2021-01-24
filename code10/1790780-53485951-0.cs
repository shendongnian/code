    private async void Execute(object sender, EventArgs e)
    {
        var dte = await package.GetServiceAsync(typeof(DTE));
        DTE2 dte2 = dte2 as DTE2;
        if(dte2 != null){
            ExecuteCommand(dte2, string.Format("View.ClassView"));
        }
    }
