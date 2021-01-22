    private delegate void SetControlTextHandler(Control control, string text);
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
