    public void MyRichTextBox_Deselect(object sender, EventArgs e)
    {
        // When user tries to select text in the rich text box, 
        // set selection to nothing and set focus somewhere else.
        RichTextBox richTextBox = sender as RichTextBox;
        richTextBox.SelectionLength = 0;
        richTextBox.SelectionStart = richTextBox.Text.Length;
    	// This is an instance of seperator bar or something else on the form (like an off screen label) to switch focus to.
        mySeperatorBar.Focus();
    }
    
    public void MyRichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
    {
    	System.Diagnostics.Process.Start(e.LinkText);
    }
