    // Event raised from RichTextBox when user clicks on a link:
    private void richTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        LaunchWeblink(e.LinkText);
    }
    // Performs the actual browser launch to follow link:
    private void LaunchWeblink(string url)
    {
        if (IsHttpURL(url)) Process.Start(url);
    }
    // Simple check to make sure link is valid,
    // can be modified to check for other protocols:
    private bool IsHttpURL(string url)
    {
        return
            ((!string.IsNullOrWhiteSpace(url)) &&
            (url.ToLower().StartsWith("http")));
    }
