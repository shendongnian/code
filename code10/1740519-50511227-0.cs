    private string languageString;
    private void btnStartTest_Click(object sender, EventArgs e)
    {
        languageString = btnStartTest.Text;
        btnStartTest.Text="⚫";
    }
    private void btnStopTest_Click(object sender, EventArgs e)
    {
       btnStartTest.Text = languageString;
       //reset the text to what it used to be.
    }
