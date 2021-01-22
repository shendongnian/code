    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            if (DialogResult == DialogResult.None)
            {
                e.Cancel = true;
            }
        }
    }
