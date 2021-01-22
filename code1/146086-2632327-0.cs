    bool m_InMyTextChanged = false;  
    private void txtMyText_TextChanged(object sender, EventArgs e)
    {
        if (m_InMyTextChanged)
            return; // Recursive!  We can bail quickly.  
        m_InMyTextChanged = true; // Prevent recursion when we change it.
        int selectionStart = txtMyText.SelectionStart;
        int selectionLength = txtMyText.SelectionLength;
        string originalText = txtMyText.Text;
        string newText = originalText.ToUpper();
        if (newText != originalText)
        {
            txtMyText.Text = newText; // Will cause a new TextChanged event.
            // Set the selection back *after* the assignment, which has reset them.
            txtMyText.SelectionStart = selectionStart;
            txtMyText.SelectionLength = selectionLength;
        }
        m_InMyTextChanged = false; // Allow it for next time.
    }
