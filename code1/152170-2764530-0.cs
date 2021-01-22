    try
    {
       SmtpClient client = new SmtpClient();
       client.Send(message);
    }
    catch(Exception exc)
    {
       // log the error, update your entry - whatever you need to do 
    }
