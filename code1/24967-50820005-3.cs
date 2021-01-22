    private static void SmtpServer_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
            {
                MailMessage thisMesage = (MailMessage) e.UserState;
                if (e.Error != null)
                {
                    if (e.Error.InnerException != null)
                    {
                        writeMessage("ERROR: Sending Mail: " + thisMesage.Subject + " Msg: "
                                     + e.Error.Message + e.Error.InnerException.Message);
                    }
    
                    else
                    {
                        writeMessage("ERROR: Sending Mail: " + thisMesage.Subject + " Msg: " + e.Error.Message);
                    }
                }
                else
                {
                    writeMessage("Success:" + thisMesage.Subject + " sent.");
                }
            if (_messagesPerConnection > 20)
            {  /*Limit # of messages per connection, 
                After send then reset the SmtpClient before next thread release*/
                _smtpServer = new SmtpClient(_mailServer);
                _smtpServer.SendCompleted += SmtpServer_SendCompleted;
                _smtpServer.Port = Convert.ToInt32(_mailPort);
                _smtpServer.UseDefaultCredentials = false;
                _smtpServer.Credentials = new NetworkCredential(_mailUser, _mailPassword);
                _smtpServer.EnableSsl = true;
                _messagesPerConnection = 0;
            }
                _autoResetEvent.Set();//Here is the event reset
                mailWaiting--;
            }
