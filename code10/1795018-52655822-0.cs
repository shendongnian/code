    var dialogResult = MessageBox.Show("Message", "System message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
    if (dialogResult == DialogResult.No)
    {
    }
    else if (dialogResult  == DialogResult.Yes)
    {
        return;
    }
    else if (dialogResult == DialogResult.Cancel)
    {
       return;
    }
