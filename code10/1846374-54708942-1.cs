    byte[] buffer = new byte[4];
    int bytesBuffered = 0;
    bool inProgress = false;
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (!inProgress) {
            // presumably this means "send me the current data?"
            inProgress = true;
            port.Write("A");            
        }
        // read whatever we still need to make 4, if available
        int bytes = Math.Min(port.BytesToRead, 4 - bytesBuffered);
        if (bytes <= 0) return; // nothing to do right now
        // read the next few bytes, noting the offset
        bytes = port.Read(buffer, bytesBuffered, bytes);
        // TODO: check if bytes is <= 0 - if so, the port may have disconnected
        bytesBuffered += bytes;
        // check whether we have enough to update the UI
        if (bytesBuffered == 4)
        {
            // we now have 4 bytes; update the UI, and reset
            int potensio = BitConverter.ToInt32(buffer, 0);
            string potString = Convert.ToString(potensio);
            label1.Text = potString;
            // and issue a new A next time
            bytesBuffered = 0;
            inProgress = false;
        }
    }
