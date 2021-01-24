    richTextBox1.LinkClicked += richtextBox1_LinkClicked;
    public void richtextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        // Opens the link in the default browser.
        Process.Start(e.LinkText);
    }
