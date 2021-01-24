    // Set client confirmation box based on current check on menu item
    client.Confirmation = confirmationToolStripMenuItem.Checked;
    if (client.ShowDialog(this) == DialogResult.OK)
    {
        // Set check on menu item based on results of confirmation dialog box
        confirmationToolStripMenuItem.Checked = client.Confirmation;
    }
