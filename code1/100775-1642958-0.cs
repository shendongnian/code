    WsClient client;
    protected override void Load() {
        base.Onload();
        client = new WsClient();
        client.GetDataCompleted += new GetDataCompletedEventHandler(client_GetDataCompleted);
    }
    //here is the call
    protected void Invoke()
    {
        client.GetDataAsync(txtSearch.Text);
    }
    
    //here is the result
    void client_GetDataCompleted(object sender, GetDataCompletedEventArgs e)
    {
        //display the result
        txtResult.Text = e.Result;
    }
