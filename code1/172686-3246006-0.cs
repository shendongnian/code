    using Quartz;
    public class SendMailJob : IJob
    {
        public void Execute(JobExecutionContext context)
        {
            SendMail();
        }
        private void SendMail()
        {
            // put your send mail logic here
        }
    }
