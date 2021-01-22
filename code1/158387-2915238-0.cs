    public class EMail
    {
        private string server;
        public string Server {get{return this.server;}set{this.server = value;}}
        private string to;
        public string To {get{return this.to;}set{this.to = value;}}
        private string from;
        public string From {get{return this.from;}set{this.from = value;}}
        private string subject;
        public string Subject {get{return this.subject;}set{this.subject = value;}}
        private string body;
        public string Body {get{return this.body;}set{this.body = value;}}
    
        public EMail()
        {}
        public EMail(string _server, string _to, string _from, string _subject, string _body)
        {
            this.Server = _server;
            this.To = _to;
            this.From = _from;
            this.Subject = _subject;
            this.Body = _body;
        }   
    
        public void Send()
        {
            using(System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(this.From, this.To, this.Subject, this.Body))
            {        
                message.IsBodyHtml = true;
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(this.Server);
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
    			
    			int temp = System.Net.ServicePointManager.MaxServicePointIdleTime; //<- Store the original value.
    			System.Net.ServicePointManager.MaxServicePointIdleTime = 1; //<- Change the idle time to 1.
    			
                try 
                {
                    client.Send(message);
                }  
                catch(System.Exception ex) 
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());              
                }
    			finally
    			{
    				System.Net.ServicePointManager.MaxServicePointIdleTime = temp; //<- Set the idle time back to what it was.
    			}
            }
        }
    }
