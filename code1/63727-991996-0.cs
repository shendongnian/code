    public partial class Form1 : Form
        {
    
            protected MessageInterceptor smsInterceptor = null;
    
            public Form1()
            {
                InitializeComponent();
                debugTxt.Text = "Calling Form cs";
                //Receiving text message
                this.smsInterceptor  = new MessageInterceptor(InterceptionAction.NotifyandDelete);
                this.smsInterceptor.MessageReceived += this.SmsInterceptor_MessageReceived;                  
            }
    
            public void SmsInterceptor_MessageReceived(object sender, 
             MessageInterceptorEventArgs e)
            {
                  SmsMessage msg = new SmsMessage();
                  msg.To.Add(new Recipient("James", "+16044352345"));
                  msg.Body = "Congrats, it works!";
                  msg.Send();  
            }
        }
