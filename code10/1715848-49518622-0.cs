    private void btnGenerateEboard_Click(object sender, EventArgs e)
    {
        string stDueTime;
        if (rbtnGB.Checked)
        {
            MethodGBSizeDueEstimate(stDueTime);
        }
        if (rbtnNative2Rel.Checked)
        {
            txtEboardText.AppendText(Environment.NewLine + stDueTime);
        }
    }
