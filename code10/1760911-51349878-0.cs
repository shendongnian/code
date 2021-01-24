    private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IPHostEntry hostEntry;
                hostEntry = Dns.GetHostEntry(textBox3.Text);
                if (hostEntry.AddressList.Length > 0)
                {
                    var ip = hostEntry.AddressList[0];
                    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                    s.Connect(ip, 80);
                    textBox5.Text = ip.ToString();
                }
            }
            catch
            {
                 textBox5.Text = "No Conversion available";
            }
