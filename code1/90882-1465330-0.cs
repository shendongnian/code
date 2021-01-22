    private void frmLibrary_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = !checkLogOff;
        if (e.Cancel)
        {
            MessageBox.Show("Please Log Off before closing the Application");
        }
    }
