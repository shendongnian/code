public static void Main(string[] args)
{
    object someArrows = ">>>";
    var users = Repository.GetUsers();
    SmtpClient client = new SmtpClient("Host");
    client.SendCompleted += SendCompletedCallback;
    MailAddress from = new MailAddress("system@domain.com", "System", Encoding.UTF8);
    int numRemaining = users.Length;
    using(ManualResetEvent waitHandle = new ManualResetEvent(numRemaining == 0))
    {
        object numRemainingLock = new object();
        foreach(var user in users)
        {
            MailAddress to = new MailAddress(user.Email);
            MailMessage message = new MailMessage(from, to);
            try
            {
                message.Body = "This is a test";
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = "test message 1" + someArrows;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                string userState = String.Format("Message for user id {0}", user.ID);
                client.SendCompleted += delegate
                {
                    lock(numRemainingLock)
                    {
                        if(--numRemaining == 0)
                        {
                            waitHandle.Set();
                        }
                    }
                };
                client.SendAsync(message, userState);
            }
            catch
            {
                message.Dispose();
                throw;
            }
        }
        waitHandle.WaitOne();
    }
}
