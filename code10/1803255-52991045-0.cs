    foreach (Control c in BookingSummaryGroupBox.Controls)
    {
        if (c is label && c.Name.Contains("yourKey"))
        {
            c.Text = "";
        }
    }
