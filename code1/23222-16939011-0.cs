    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using System.Net.Mail;
    
    namespace SendMail
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                    MailMessage msg = new MailMessage();
    
                    NetworkCredential cred = new NetworkCredential("x@gmail.com", "password");
                    msg.From = new MailAddress("x@gmail.com");
                    msg.To.Add("y@gmail.com");
                    msg.Subject = "A subject";
                    msg.Body = "Hello,Raffi";
    
                    client.Credentials = cred;
                    client.EnableSsl = true;
                    label1.Text = "Mail Sended Succesfully";
                    client.Send(msg);
    
    
                }
                catch
                {
                    label1.Text = "Error";
                }
            }
    
    
    
        }
    }
