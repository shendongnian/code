    public void SendMessage()
    {
        try
        {
            using (SmtpClient client = new SmtpClient())
            {
                client.Send(Message);
            client.dispose()
    
            }
        }
        finally
        {
            DisposeAttachments(); 
        }
    }
