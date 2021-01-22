    public interface IMailWrapper {
        /* members used from System.Net.Mail class */
    }
    
    public class MailWrapper {
        private System.Net.Mail original;
        public MailWrapper( System.Net.Mail original ) {
            this.original = original;
        }
    
        /* members used from System.Net.Mail class delegated to "original" */
    }
    
    public class MockMailWrapper {
       /* mocked members used from System.Net.Mail class */
    }
    void YourMethodUsingMail( IMailWrapper mail ) {
        /* do something */
    }
