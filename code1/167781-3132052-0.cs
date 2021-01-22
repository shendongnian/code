    void MyForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            // User clicked the close button.
            // Cancel if dialogs are open.
            if (dialogsOpen)
            {
                e.Cancel = true;
            }
        }
    }
