    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Net.Mail;
    using System.Text;
    using System.ComponentModel;
    
    public partial class UserControls_LandingPage_contactForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool bSent = false;
            try
            {
                //create the email and add the settings
                var email = new MailMessage();
                email.From = new MailAddress(FromEmail);
                email.To.Add(new MailAddress(FromEmail));
                email.Subject = Subject;
                email.IsBodyHtml = true;
    
                //build the body
                var sBody = new StringBuilder();
                sBody.Append("<strong>Contact Details</strong><br /><br />");
                sBody.AppendFormat("Needs: {0}<br />", cboConsultationType.SelectedValue);
                sBody.AppendFormat("Name: {0}<br />", txtName.Text);
                sBody.AppendFormat("Email: {0}<br />", txtEmail.Text);
                sBody.AppendFormat("Number: {0}<br />", txtPhone.Text);
                sBody.AppendFormat("Comment: {0}<br />", txtMsg.Text);
                email.Body = sBody.ToString();
    
                //send the email
                var smtpServer = new SmtpClient();
                smtpServer.Send(email);
    
                //mark as sent ok
                bSent = true;
            }
            catch (Exception ex)
            {
                //send any errors back
                //add your own custom handling of errors;
            }
    
            //let the end user know if it was a success
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + (bSent ? SuccessText : FailureText) + "');", true);
        }
    
        //properties    
        public string FromEmail
        {
            get { return _fromEmail; }
            set { _fromEmail = value; }
        }
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        public string SuccessText
        {
            get { return _successText; }
            set { _successText = value; }
        }
        public string FailureText
        {
            get { return _failureText; }
            set { _failureText = value; }
        }
    
        //fields
        private string _fromEmail = "info@example.com.au";
        private string _subject = "Website Enquiry";
        private string _successText = "Thank you for submitting your details we will be in touch shortly.";
        private string _failureText = "There was a problem submitting your details please try again shortly.";
    
    }
