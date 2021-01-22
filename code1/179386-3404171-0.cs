    DialogResult result = MessageBox.Show();
    if (result == DialogResult.Yes)
    {
        navigateForward(WEB_PAGE_NAVIGATE);
    }
    else
    {
        // No need to do anything here as the MessageBox is closed automatically.
    }
