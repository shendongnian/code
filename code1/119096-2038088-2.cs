    private void richTextBox1_KeyDown(object sender, KeyEventArgs e) 
    { 
        if (e.Control && e.KeyCode == Keys.V)  
        { 
                // suspend layout to avoid blinking
                richTextBox2.SuspendLayout();
    
                // get insertion point
                int insPt = richTextBox2.SelectionStart;
    
                // preserve text from after insertion pont to end of RTF content
                string postRTFContent = richTextBox2.Text.Substring(insPt);
    
                // remove the content after the insertion point
                richTextBox2.Text = richTextBox2.Text.Substring(0, insPt);
    
                // add the clipboard content and then the preserved postRTF content
                richTextBox2.Text += (string)Clipboard.GetData("Text") + postRTFContent;
    
                // adjust the insertion point to just after the inserted text
                richTextBox2.SelectionStart = richTextBox2.TextLength - postRTFContent.Length;
    
                // restore layout
                richTextBox2.ResumeLayout();
    
                // cancel the paste
                e.Handled = true;
        } 
    } 
