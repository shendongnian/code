    private void SetStatus(string statusMessage)
    {
        this.InvokeHandler(delegate
        {
            resultLabel.Text = statusMessage;
        });
    }
