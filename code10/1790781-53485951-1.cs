    private async void Execute(object sender, EventArgs e)
    {
        DTE2 dte2 = await package.GetServiceAsync(typeof(DTE)).ConfigureAwait(false) as DTE2;
        if(dte2 != null){
            ExecuteCommand(dte2, string.Format("View.ClassView"));
        }
    }
