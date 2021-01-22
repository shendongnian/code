    public void log(String msg, Color? c = null)
    {
        loggerText.ForeColor = c ?? Color.Black;
        loggerText.AppendText("\n" + msg);
    }
