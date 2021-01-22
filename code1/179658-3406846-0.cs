    private void WriteLine(string message, bool useLogFile)
    {
        if (base.NeedIndent)
        {
            this.WriteIndent();
        }
        this.Write(message + "\r\n", useLogFile);
        base.NeedIndent = true;
    }
