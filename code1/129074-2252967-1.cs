    public void MyRichTextBox_Deselect(object sender, EventArgs e)
    {
        // When user tries to select text in the rich text box, 
        // set selection to nothing and set focus somewhere else.
        RichTextBox richTextBox = sender as RichTextBox;
        richTextBox.SelectionLength = 0;
        richTextBox.SelectionStart = richTextBox.Text.Length;
    	// In this case I use an instance of separator bar on the form to switch focus to.
        // You could equally set focus to some other element, but take care not to
        // impede accessibility or visibly highlight something like a label inadvertently.
        // It seems like there should be a way to drop focus, perhaps to the Window, but
        // haven't found a better approach. Feedback very welcome.
        mySeperatorBar.Focus();
    }
    
    public void MyRichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
    {
    	System.Diagnostics.Process.Start(e.LinkText);
    }
