    private void RecieveArg_Completed(object sender, SocketAsyncEventArgs e)
        {
            byte[] recBuf = new byte[e.BytesTransferred];
            Array.Copy(buffer, recBuf, e.BytesTransferred);
            string ReceivedText = Encoding.ASCII.GetString(recBuf);
            txt_Events.Text = ReceivedText;
            Client_Socket.ReceiveAsync(RecieveArg);
        }
