    public static async Task Main(string[] args)
    {
        var theQueue = new BlockingCollection<EmailModel>(new ConcurrentQueue<EmailModel>());
        var primaryWork = new PrimaryWork(theQueue);
        var mailSender = new EmailSender(theQueue);
        mailSender.Start();
        primaryWork.DoWork();
        // Wait for all mails to be sent 
        await mailSender.Stop();
    }
