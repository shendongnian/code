    public void SetControlText(Control control, string text)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new SetControlTextHandler(SetControlText), new object[] { control, text });
        }
        else
        {
            control.Text = text;
        }
    }
