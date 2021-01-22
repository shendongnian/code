    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Net;
    using System.Net.Mail;
    
    public partial class SendMail : System.Web.UI.Page
    {
    
        protected void btnSend_Click(object sender, EventArgs e)
        {
    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
    
    msg.From = new MailAddress("xxx@yourdomain.com");
    
    msg.To.Add(txtTo.Text);//Text Box for To Address
    
    msg.Subject = txtSubject.Text; //Text Box for subject
    
    msg.IsBodyHtml = true;
    
    msg.Body = txtBody.Text;//Text Box for body
    
    msg.Priority = MailPriority.High;
    
    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net", 25);
    
    client.UseDefaultCredentials = false;
    
    client.Credentials = new System.Net.NetworkCredential("xxx@yourdomain.com", "yourpassword");
    
    client.Port = 25;
    
    client.Host = "relay-hosting.secureserver.net";
    
    client.EnableSsl = false;
    
    object userstate = msg;
    
    client.Send(msg);
    
    }
        }
