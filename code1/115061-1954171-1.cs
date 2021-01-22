    public partial class Form1 : Form
    {
        protected Outlook.Application App;
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(Outlook.Application _app)
        {
            App = _app;
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            label1.Text = "Total number of mails in inbox: " + App.ActiveExplorer().CurrentFolder.Items.Count.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Outlook.MailItem item = (Outlook.MailItem)App.ActiveInspector().CurrentItem;
            textBox1.Text += "From:    " + item.SenderName + "\r\n\n";
            textBox1.Text += "Subject: " + item.Subject + "\r\n\n";
            textBox1.Text += "Body: \r\n\n" + item.Body + "\r\n";
            textBox1.Text += "Mail contains:    " + item.Attachments.Count + " attachment(s).\r\n\n";
        }
    }
}
