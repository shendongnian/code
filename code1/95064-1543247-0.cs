    public byte[] ReadAllBytesFromStream(Stream input)
    {
        if(this.InvokeRequired)
        {
            this.Invoke(new MethodInvoker(clock.Start));
        }
        else
        {
            clock.Start();
        }
        using (...)
        {
            while (some conditions) //here we read all bytes from a stream (FTP)
            {
                ...
     (int-->)   ByteCount = aValue;
                ...
             }
            return .... ;
        }
    }
    private void clock_Tick(object sender, EventArgs e)
    {
        this.label6.Text = ByteCount.ToString() + " B/s"; //show how many bytes we have read in each second
    }
