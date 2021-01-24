    var dialogResult = MessageBox.Show("Message", "System message",
                                       MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
    if (dialogResult  == DialogResult.Yes || dialogResult == DialogResult.Cancel)
    {
        return;
    }
    
    // logic for No here
    // as this means No was pressed
    
