    private void AddControls()
    {
        if(panelMain.InvokeRequired)
        {
            panelMain.BeginInvoke(new MethodInvoker(AddControls));
            return;
        }
        foreach (UserStatus friendStatus in list)
        {
            PictureBox pbTweet = new PictureBox();
            // ...
            // code to set numerous properties
            // ...
            RichTextBox rtbTweet = new RichTextBox();
            // ...
            // code to set numerous properties
            // ...
        
            Panel panelTweet = new Panel();
            // ...
            // code to set numerous properties
            // ...
        
            panelTweet.Controls.Add(pbTweet);
            panelTweet.Controls.Add(rtbTweet);
            panelMain.Controls.Add(panelTweet)
        }
    }
