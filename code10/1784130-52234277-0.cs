    private void F0100_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Do not prompt the user if we have called Application.Restart
        if(e.CloseReason != CloseReason.ApplicationExitCall)
        {
            DialogResult result;
            ....
        }
    }
