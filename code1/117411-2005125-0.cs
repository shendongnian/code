    private bool ClosingDone;
    public void Closing(object sender, EventArgs e)
    {
        if (!ClosingDone)
        {
            ClosingDone = true;
            // Code, which can trigger Closing again
        }
    }
