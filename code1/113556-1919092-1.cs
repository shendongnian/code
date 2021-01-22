    private void buttonSend_Click(object sender, EventArgs e)
    {
        // send text
        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textSend.Text + "$");
        serverStream.Write(outStream, 0, outStream.Length);
        serverStream.Flush();
        // clear textbox
        textSend.Text = "";
    }
