    public void button1_Click(object sender, EventArgs e)
    {
        // Exits the application
        Application.Exit();
    }
    private void xGameForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        //Yes or no message box to exit the application
        DialogResult Response;
        Response = MessageBox.Show("Are you sure you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        if (Response == DialogResult.No)
            // Cancel the close, prevents applications from exiting.
            e.Cancel = true;
    }
