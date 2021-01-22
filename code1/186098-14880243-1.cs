    private void SetText(Control control, string text)
    {
        if (control.InvokeRequired)
             this.Invoke(new Action<Control>((c) => c.Text = text),control);
        else
            control.Text = newText; 
    }
