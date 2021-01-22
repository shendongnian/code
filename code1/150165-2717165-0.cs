    private void button1_Click(object sender, EventArgs e)
    {
        uint bufferSize = 2;
        StringBuilder buffer = new StringBuilder();
        StringBuilder final = new StringBuilder();
        uint bytesRead;
        NativeMethods.WTSVirtualChannelRead(mHandle, 0, buffer, bufferSize, out bytesRead);
        while (bytesRead != 0)
        {
            final.Append(buffer);
            NativeMethods.WTSVirtualChannelRead(mHandle, 0, buffer, bufferSize, out bytesRead);
        }
            MessageBox.Show("Got data: " + final.ToString());
    }
