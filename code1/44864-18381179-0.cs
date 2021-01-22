    void rec(IAsyncResult ar)
    {
      StringBuilder receivedData;
      //String oldvalue;
      Socket remote = (Socket)ar.AsyncState;
      int recv = remote.EndReceive(ar);
      receivedData = new StringBuilder(Encoding.ASCII.GetString(receive, 0, recv));
      //MessageBox.Show(receivedData.ToString(), "received", MessageBoxButtons.OK);
      StringBuilder sb = new StringBuilder(this.textBox1.Text);
      sb.AppendLine(receivedData.ToString());
      if (textBox1.InvokeRequired)
      {
        this.Invoke((MethodInvoker)delegate { this.textBox1.Text = sb.ToString(); });
        
      }
      remote.BeginReceive(receive, 0, receive.Length, System.Net.Sockets.SocketFlags.None, new AsyncCallback(rec), remote);
      //remote.Close(5);
      return;
    }
