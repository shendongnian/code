    public class ClassUnderTest : Base
    {
        private IMail mail;
        private IMailer mailer
    
        public ClassUnderTest()
        {
            mail = new Mail() { /* ... */ };
            mailer = new Mailer() { /* ... */ }
        }
        public ClassUnderTest(IMail mail, IMailer mailer)
        {
            this.mail = mail;
            this.mailer = mailer;
        }
        public override MethodUnderTest()
        {
            if(condition)
            {
                mailer.Send(mail);
            }
            else
            {
                /* ... */
            }
        }
    }
