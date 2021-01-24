    public async Task WaitMessages()
    {
        var reader = new StreamReader(LoginChat.Client.TcpClt.GetStream());
        while (LoginChat.Client.Connected)
        {
            try
            {                
                var data = await reader.ReadLineAsync();
                MessageBox.Show(data);
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.ToString());  
            }
        }
    }
