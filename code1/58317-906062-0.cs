    public void UpdateTestBox(string newText)
    {
        if (InvokeRequired)
        {
            BeginInvoke(new Action<string>(UpdateTestBox), new object[] { newText });
            return;
        }
        tb_output.Text = newText;
    }
