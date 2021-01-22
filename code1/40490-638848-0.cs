    private void SetStatus(string statusMessage)
    {
        InvokeHandler(delegate
        {
            resultLabel.Text = statusMessage;
        });
    }
