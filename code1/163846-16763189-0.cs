    // Variable
    string MessageBoxTitle = "Some Title";
    string MessageBoxContent = "Sure";
    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
    if(dialogResult == DialogResult.Yes)
    {
        //do something
    }
    else if (dialogResult == DialogResult.No)
    {
        //do something else
    }
