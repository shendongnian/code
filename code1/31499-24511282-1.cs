    static void setTextboxText(int result)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new IntDelegate(SetTextboxTextSafe), new object[] { result }); 
        }
        else
        {
            SetTextboxTextSafe(result);
        }
    }
