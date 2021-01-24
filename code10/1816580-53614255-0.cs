    class MailData
    {
        public string subject;
        public Item mailItem;
        public MailData(string subject, Item mailItem)
        {
            this.subject = subject;
            this.mailItem = mailItem;
        }
        public override string ToString() => subject;
        
    }
