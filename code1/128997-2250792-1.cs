    private delegate void MyDelegate();
    
    private void UpdateText()
    {
        if (button1.InvokeRequired)
        {
           button1.Invoke(new MyDelegate(UpdateText));
        }
        button1.Text = "New Text";
    }
